using IdentityNotes.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityNotes.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (base.IsUserAuthenticated)
            {
                return RedirectToAction("MyNotes", "Note");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
