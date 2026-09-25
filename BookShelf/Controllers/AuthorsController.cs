using BookShelf.Data;
using BookShelf.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookShelfDbContext _dbContext;

        public AuthorsController(BookShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /* Default Controller Route Convention:
           Path: {Controller}/{Action} -> GET /Authors/Index
           View Discovery Default Convention -> View is searched in the same path as Path from HTTP Request
           Views are always searched in Views folder
        0. If explicit View name is passed, then View Discovery will search view with the explicit name
        1. View is searched in folder named as the Controller and view name should equal to action name
        -> Views/Authors/Index.cshtml
        2. If view is not found based on the above convention, View Discovery searches for View with the name of the action in the Shared folder
        */

        public IActionResult Index()
        {
            IEnumerable<Author> allAuthorsWithBooks = _dbContext.Authors
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country)
                .ThenBy(a => a.Id)
                .Take(10)
                .ToArray();

            return View(allAuthorsWithBooks);
        }
    }
}
