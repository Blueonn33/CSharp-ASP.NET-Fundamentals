using Homies.Data;
using Homies.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;
using static Homies.Common.ApplicationConstants;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext _dbContext;
        public EventController(HomiesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult All()
        {
            IEnumerable<EventAllViewModel> allEventsViewModel = _dbContext.Events
                .OrderBy(e => e.Name)
                .ThenByDescending(e => e.Start)
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DateTimeFormat),
                    TypeName = e.Type.Name,
                    OrganizerUsername = e.Organizer.UserName ?? string.Empty
                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(allEventsViewModel);
        }
    }
}
