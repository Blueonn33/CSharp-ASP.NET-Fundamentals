using GameZone.Data;
using GameZone.Data.Models;
using GameZone.ViewModels.Game;
using GameZone.ViewModels.Genre;
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
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, GameZoneDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
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

        [HttpGet]
        public IActionResult Add()
        {
            GameInputModel inputModel = new GameInputModel()
            {
                ReleasedOn = DateTime.Today,
                Genres = LoadAllGenresDropDownItems()
            };

            return View(inputModel);
        }

        [HttpPost]
        public IActionResult Add([FromForm] GameInputModel inputModel)
        {
            // By default, [FromForm] is used, so it is not necessary to write it

            if (!ModelState.IsValid)
            {
                inputModel.Genres = LoadAllGenresDropDownItems();

                // Return the same View as GET Method, but pre-filled with User Input Bind Data + Automatically filled Model Validation Errors
                return View(inputModel);
            }

            bool genreExists = _dbContext.Genres
                .Any(g => g.Id == inputModel.GenreId);

            if (!genreExists)
            {
                ModelState.AddModelError(nameof(GameInputModel.GenreId), "Invalid genre is selected");
                inputModel.Genres = LoadAllGenresDropDownItems();

                return View(inputModel);
            }

            try
            {
                Game newGame = new Game()
                {
                    Title = inputModel.Title,
                    ImageUrl = inputModel.ImageUrl,
                    Description = inputModel.Description,
                    PublisherName = inputModel.PublisherName,
                    ReleasedOn = inputModel.ReleasedOn,
                    GenreId = inputModel.GenreId
                };

                _dbContext.Games.Add(new Game());
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogCritical("Error occurred while saving valid Game data! Check logs");

                TempData["Error"] = "Unexpected error occured while saving your data";
                return RedirectToAction(nameof(All));
            }
        }

        private IEnumerable<GenreDropDownViewModel> LoadAllGenresDropDownItems()
        {
            IEnumerable<GenreDropDownViewModel> allGenres = _dbContext.Genres
                .Select(g => new GenreDropDownViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .OrderBy(g => g.Name)
                .ToArray();

            return allGenres;
        }
    }
}
