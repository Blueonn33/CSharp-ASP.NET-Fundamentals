using Homies.DataTransferObjects.Event;
using Homies.Services.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly ITypeService typeService;

        public EventController(
            IEventService _eventService, 
            ITypeService _typeService)
        {
            eventService = _eventService;
            typeService = _typeService;
        }

        public async Task<IActionResult> Add()
        {
            var eventModel = await eventService.GetEventFormModelAsync();

            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel eventModel)
        {
            if ((await typeService.GetTypesAsync())
                .Any(e => e.Id == eventModel.TypeId) == false)
            {
                ModelState.AddModelError(nameof(eventModel.TypeId), "Type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            string currentUserId = GetUserId();
            await eventService.AddEventAsync(eventModel, currentUserId);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> All()
        {
            var eventsToDisplay = await eventService.GetAllAsync();

            return View(eventsToDisplay);
        }

        public async Task<IActionResult> Join(int id)
        {
            bool result = await eventService.JoinAsync(id, GetUserId());

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Leave(int id)
        {
            bool result = await eventService.LeaveAsync(id, GetUserId());
            
            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Joined()
        {
            var userEvents = await eventService.GetJoinedEventsAsync(GetUserId());

            return View(userEvents);
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventToDisplay = await eventService.GetEventDetailsAsync(id);

            if (eventToDisplay == null)
            {
                return BadRequest();
            }

            return View(eventToDisplay);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var eventModel = await eventService.GetEventForEditAsync(id, GetUserId());

                if (eventModel == null)
                {
                    return BadRequest();
                }

                return View(eventModel);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {
                bool result = await eventService.EditEventAsync(id, model, GetUserId());

                if (result == false)
                {
                    return BadRequest();
                }

                return RedirectToAction("All", "Event");
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (ArgumentException aex)
            {
                ModelState.AddModelError(nameof(model.TypeId), aex.Message);

                return View(model);
            }
        }

        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
