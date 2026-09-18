using GarageApp.Data;
using GarageApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Controllers
{
    public class CarController : Controller
    {
        private readonly GarageAppDbContext _dbContext;

        public CarController(GarageAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Car> allCars = _dbContext.Cars
                .Include(c => c.Garage)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ThenByDescending(c => c.Year)
                .ThenByDescending(c => c.ProductionMonth)
                .Take(25)
                .ToArray();

            return View(allCars);
        }

        [HttpGet]
        public IActionResult Search(string? make)
        {
            if (string.IsNullOrEmpty(make))
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<Car> allCars = _dbContext.Cars
                .Include(c => c.Garage)
                //.Where(c => c.Make.ToString().ToLower().Contains(make.ToLower()))
                .Where(c => EF.Functions.Like(c.Make, $"%{make.ToLower()}%"))
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ThenByDescending(c => c.Year)
                .ThenByDescending(c => c.ProductionMonth)
                .Take(25)
                .ToArray();

            return View(nameof(Index), allCars);
        }
    }
}
