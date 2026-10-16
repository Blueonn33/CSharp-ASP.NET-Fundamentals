using Homies.Services.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Web.Controllers
{
    public class EventController(IEventService eventService, ITypeService typeService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var eventModel = eventService.GetEventInputModel();

            return View(eventModel);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
