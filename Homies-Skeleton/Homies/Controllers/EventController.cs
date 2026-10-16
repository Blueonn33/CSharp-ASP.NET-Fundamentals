using Homies.Data;
using Homies.DTO.Event;
using Homies.DTO.Type;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Web.Controllers
{
    public class EventController(HomiesDbContext dbContext) : Controller
    {
        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            throw new NotImplementedException();
        }

        public IActionResult Add(EventInputModel eventModel)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<TypeViewModel> GetTypes()
        {
            return dbContext.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                });
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
