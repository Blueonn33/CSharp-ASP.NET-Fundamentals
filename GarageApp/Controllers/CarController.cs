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
        public IActionResult Index(string? make)
        {
            IQueryable<Car> allCarsQuery = _dbContext.Cars
                .Include(c => c.Garage)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ThenByDescending(c => c.Year)
                .ThenByDescending(c => c.ProductionMonth)
                .Take(25);

            if (!String.IsNullOrEmpty(make))
            {
                allCarsQuery = allCarsQuery
                    .Where(c => EF.Functions.Like(c.Make, $"%{make.ToLower()}%"));
            }

            IEnumerable<Car> allCars = allCarsQuery.ToArray();

            return View(allCars);
        }
    }
}
