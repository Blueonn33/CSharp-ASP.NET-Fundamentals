using Microsoft.AspNetCore.Mvc;
using MvcIntro.ViewModels;

namespace MvcIntro.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            var model = new PersonViewModel
            {
                Id = 1,
                FirstName = "Martin",
                LastName = "Marinov",
                Age = 13
            };

            return View(model);
        }
    }
}
