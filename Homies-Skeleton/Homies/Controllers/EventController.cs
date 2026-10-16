using Homies.DTO.Event;
using Homies.Services.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Web.Controllers
{
    [Authorize]
    public class EventController(IEventService eventService, ITypeService typeService) : Controller
    {
        [HttpGet]
        public IActionResult All()
        {
            var eventsToDisplay = eventService.GetAll();

            return View(eventsToDisplay);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var eventModel = eventService.GetEventInputModel();

            return View(eventModel);
        }

        [HttpPost]
        public IActionResult Add(EventInputModel eventModel)
        {
            if (typeService
                    .GetTypes()
                    .Any(e => e.Id == eventModel.TypeId) == false)
            {
                ModelState.AddModelError(nameof(eventModel.TypeId), "Type does not exist");
            }

            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            string userId = GetUserId();
            eventService.AddEvent(eventModel, userId);

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public IActionResult Join(int id)
        {
            bool result = eventService.Join(id, GetUserId());

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("Joined", "Event");
        }

        [HttpGet]
        public IActionResult Leave(int id)
        {
            bool result = eventService.Leave(id, GetUserId());

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public IActionResult Joined()
        {
            return View();
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
