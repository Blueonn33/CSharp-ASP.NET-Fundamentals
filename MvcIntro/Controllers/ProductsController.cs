using Microsoft.AspNetCore.Mvc;

namespace MvcIntro.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return Ok("All  products");
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