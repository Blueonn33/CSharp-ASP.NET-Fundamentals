using BookShelf.Data;
using BookShelf.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookShelfDbContext _dbContext;
        public BooksController(BookShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> allBooksWithAuthors = _dbContext.Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .ThenByDescending(b => b.Year)
                .ThenBy(b => b.Id)
                .Take(10)
                .ToArray();

            return View(allBooksWithAuthors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Author> allAuthors = _dbContext.Authors
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country)
                .ThenBy(a => a.Id)
                .ToArray();

            ViewBag.Authors = allAuthors;

            return View();
        }


        [HttpPost]
        public IActionResult Create(Book book)
        {
            IEnumerable<Author> allAuthors = _dbContext.Authors
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country)
                .ThenBy(a => a.Id)
                .ToArray();

            bool authorExists = allAuthors
                .Any(a => a.Id == book.AuthorId);

            if (!authorExists)
            {
                ModelState.AddModelError(nameof(Book.AuthorId), "Invalid author was selected");
                ViewBag.Authors = allAuthors;

                return View(book);
            }

            try
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "General error occurred");
                ViewBag.Authors = allAuthors;

                return View(book);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
