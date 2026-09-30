using EventManager.Data;
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
        public IActionResult Index()
        {
            IEnumerable<EventIndexViewModel> allEventsViewModels = _dbContext.Events
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

            return View(allEventsViewModels);
        }
    }
}
