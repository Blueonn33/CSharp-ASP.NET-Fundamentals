using GarageApp.Data;
using GarageApp.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarageApp.Controllers
{
    public class GarageController : Controller
    {
        private readonly GarageAppDbContext _dbContext;

        public GarageController(GarageAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // URL Path is: domain/Garage/Index
            // View Path is: Views/Garage/Index.cshtml
            IEnumerable<Garage> allGarages = _dbContext.Garages
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Location)
                .Take(25)
                .ToArray();

            return View(allGarages);
        }
    }
}