using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();
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
