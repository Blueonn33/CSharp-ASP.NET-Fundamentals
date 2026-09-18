using GarageApp.Data;
using GarageApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .Include(g => g.Cars)
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Location)
                .Take(25)
                .ToArray();

            return View(allGarages);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Глупак");
            }

            Garage? garageDetails = _dbContext.Garages
                .Include(g => g.Cars)
                .SingleOrDefault(g => g.Id == id);

            if (garageDetails == null)
            {
                return NotFound("Внимавай какво търсиш");
            }

            return View(garageDetails);
        }
    }
}