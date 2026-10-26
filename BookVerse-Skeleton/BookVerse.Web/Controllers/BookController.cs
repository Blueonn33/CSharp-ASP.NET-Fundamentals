using BookVerse.Services.Core.Contracts;
using BookVerse.Services.Data.Book.Request;
using BookVerse.Services.Data.Book.Response;
using BookVerse.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookVerse.GCommon.ApplicationConstants;

namespace BookVerse.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();

            IEnumerable<GetAllBooksResponseData> allBooksResponseData = await bookService.GetAllBooksAsync();

            foreach (var bookData in allBooksResponseData)
            {
                GetUsersListedBookRequestData usersListedBookRequestData = new GetUsersListedBookRequestData()
                {
                    BookId = bookData.Id
                };

                GetUsersListedBookResponseData usersListedBookData = await bookService.GetUsersIdsListedBookByIdAsync(usersListedBookRequestData);

                BookIndexViewModel bookViewModel = new BookIndexViewModel()
                {
                    Id = bookData.Id,
                    Title = bookData.Title,
                    CoverImageUrl = bookData.CoverImageUrl ?? DefaultCoverImageUrl,
                    Genre = bookData.GenreName,
                    SavedCount = usersListedBookData.UsersListedIds.Count(),
                    IsPublisher = bookData.PublisherId == userId
                };
            }

            IEnumerable<BookIndexViewModel> allBooksViewModel = allBooksResponseData
                .Select(b => new BookIndexViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = b.GenreName,
                    CoverImageUrl = b.CoverImageUrl ?? DefaultCoverImageUrl,
                    SavedCount =
                })


            var books = await _bookService.GetAllBooksAsync(userId);

            return View(books);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> MyBooks()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyBooks(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

        public async Task<IActionResult> ConfirmDelete(int id)
        {
            return Ok();
        }
    }
}
