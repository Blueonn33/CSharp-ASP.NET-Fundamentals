using GameZone.Data;
using GameZone.ViewModels.Game;
using Microsoft.AspNetCore.Mvc;
using static GameZone.Common.ApplicationConstants;

namespace GameZone.Controllers
{
    public class GameController : Controller
    {
        // Dependency Injection (Constructor Injection)
        // ASP.NET Core Specifics:
        // Lifetime scope of Controller matches HTTP Request-Response scope
        // DbContext is injected through Constructor Injection, we should take care that every HTTP Request-Response to use new instance of DbContext
        // .AddDbContext<>() methods registers DbContext as Scoped Service .
        // Scoped Service Lifetime -> new instance lives only for the current context
        private readonly GameZoneDbContext _dbContext;

        public GameController(GameZoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult All()
        {
            IEnumerable<GameAllViewModel> games = _dbContext.Games
                .OrderByDescending(g => g.ReleasedOn)
                .ThenBy(g => g.Title)
                .ThenBy(g => g.Genre.Name)
                .Select(g => new GameAllViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.PublisherName,
                    ReleasedOn = g.ReleasedOn.ToString(ApplicationDateFormat),
                    GenreName = g.Genre.Name
                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(games);
        }
    }
}
