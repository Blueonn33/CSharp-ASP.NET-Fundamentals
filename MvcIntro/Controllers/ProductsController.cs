using Microsoft.AspNetCore.Mvc;

namespace MvcIntro.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly IEnumerable<string> products = new List<string>
        {
            "Laptops",
            "Gaming consoles",
            "TVs"
        };

        public IActionResult Index()
        {
            ViewData["Products"] = products;
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Product ID is required");
            }

            if (id <= 0)
            {
                return NotFound("Product not found");
            }

            return Ok($"Product details: {id}");
        }
    }
}