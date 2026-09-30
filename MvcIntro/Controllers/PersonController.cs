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

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PersonViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the new person to the database (not implemented) 
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
