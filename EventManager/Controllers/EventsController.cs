using EventManager.Data;
using EventManager.Data.Models;
using EventManager.ViewModels.Category;
using EventManager.ViewModels.Events;
using Microsoft.AspNetCore.Mvc;
using static EventManager.Common.ApplicationConstants;

namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventManagerDbContext _dbContext;

        public EventsController(EventManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(string? title, int? categoryId, DateTime? startDate, DateTime? endDate)
        {
            var eventsQuery = _dbContext.Events.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                string titleFilter = title.Trim();
                eventsQuery = eventsQuery.Where(e => e.Title.Contains(titleFilter));
            }

            if (categoryId.HasValue)
            {
                eventsQuery = eventsQuery.Where(e => e.CategoryId == categoryId.Value);
            }

            if (startDate.HasValue)
            {
                eventsQuery = eventsQuery.Where(e => e.StartDate >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                DateTime endDateExclusive = endDate.Value.Date.AddDays(1);
                eventsQuery = eventsQuery.Where(e => e.StartDate < endDateExclusive);
            }

            IEnumerable<EventIndexViewModel> allEventsViewModels = eventsQuery
                .OrderByDescending(e => e.StartDate)
                .ThenBy(e => e.EndDate)
                .ThenBy(e => e.Title)
                .Select(e => new EventIndexViewModel()
                {
                    Id = e.Id,
                    Title = e.Title,
                    CategoryName = e.Category.Name,
                    StartDate = e.StartDate.ToString(DateTimeFormat),
                    EndDate = e.StartDate.ToString(DateTimeFormat),
                    CurrentParticipants = e.Participants.Count(),
                    MaxParticipants = e.MaxParticipants,
                    Description = e.Description
                })
                .Take(EntitiesPerPage)
                .ToArray();

            EventIndexPageViewModel pageViewModel = new EventIndexPageViewModel()
            {
                Events = allEventsViewModels,
                Title = title,
                CategoryId = categoryId,
                StartDate = startDate,
                EndDate = endDate,
                Categories = LoadAllCategoriesDropdownData()
            };

            return View(pageViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<CategoryDropdownViewModel> allCategoriesDropdownVms = LoadAllCategoriesDropdownData();

            EventInputModel inputModel = new EventInputModel()
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                AllCategories = allCategoriesDropdownVms
            };

            return View(inputModel);
        }

        [HttpPost]
        public IActionResult Create(EventInputModel inputEvent)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid event data");
                inputEvent.AllCategories = LoadAllCategoriesDropdownData();

                return View(inputEvent);
            }

            bool categoryValid = _dbContext.Categories
                .Any(c => c.Id == inputEvent.CategoryId);

            if (!categoryValid)
            {
                ModelState.AddModelError(nameof(EventInputModel.CategoryId), "Invalid category is selected");
                inputEvent.AllCategories = LoadAllCategoriesDropdownData();

                return View(inputEvent);
            }

            //We have a validation for this in the EventInputModel
            /*
            if (inputEvent.StartDate > inputEvent.EndDate)
            {
                ModelState.AddModelError(string.Empty, "The start date cannot be later than end date");
                inputEvent.AllCategories = LoadAllCategoriesDropdownData();

                return View(inputEvent);
            }
            */

            try
            {
                Event newEvent = new Event()
                {
                    Title = inputEvent.Title,
                    Description = inputEvent.Description,
                    StartDate = inputEvent.StartDate,
                    EndDate = inputEvent.EndDate,
                    MaxParticipants = inputEvent.MaxParticipants,
                    CategoryId = inputEvent.CategoryId
                };

                _dbContext.Events.Add(newEvent);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<CategoryDropdownViewModel> LoadAllCategoriesDropdownData()
        {
            IEnumerable<CategoryDropdownViewModel> allCategoriesDropdownVms = _dbContext.Categories
                .Select(c => new CategoryDropdownViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Id)
                .ToArray();

            return allCategoriesDropdownVms;
        }
    }
}
