using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
