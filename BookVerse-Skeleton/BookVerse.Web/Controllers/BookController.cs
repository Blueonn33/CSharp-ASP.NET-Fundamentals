using BookVerse.Services.Core.Contracts;
using BookVerse.Services.Data.Book.Request;
using BookVerse.Services.Data.Book.Response;
using BookVerse.Services.Data.Genre.Response;
using BookVerse.ViewModels.Book;
using BookVerse.ViewModels.Genre;
using BookVerse.ViewModels.ReadingList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static BookVerse.GCommon.ApplicationConstants;

namespace BookVerse.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        private readonly IUserStore<IdentityUser> userStore;

        public BookController(IBookService bookService, IGenreService genreService, IUserStore<IdentityUser> userStore)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.userStore = userStore;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();

            IEnumerable<GetAllBooksResponseData> allBooksResponseData = await bookService.GetAllBooksAsync();

            ICollection<BookIndexViewModel> allBooksViewModelsList = new List<BookIndexViewModel>();

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
                    IsPublisher = bookData.PublisherId.ToLowerInvariant() == userId?.ToLowerInvariant(),
                    IsSaved = usersListedBookData.UsersListedIds
                        .Any(id => id.ToLowerInvariant() == userId?.ToLowerInvariant())
                };

                allBooksViewModelsList.Add(bookViewModel);
            }

            return View(allBooksViewModelsList);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid request");
            }

            GetBookDetailsResponseData? bookDetailsResponseData = await bookService.GetBookByIdAsync(id);

            if (bookDetailsResponseData == null)
            {
                return NotFound("The book you are looking for does not exist");
            }

            string? userId = GetUserId();
            string publisherName = UnknownUsername;
            bool isBookSavedByUser = false;
            bool isBookPublishedByUser = false;

            if (userId != null)
            {
                IdentityUser? identityUser = await userStore.FindByIdAsync(userId, CancellationToken.None);

                if (identityUser == null)
                {
                    return Unauthorized("You must be logged in to view this page");
                }

                publisherName = identityUser.UserName ?? UnknownUsername;

                isBookSavedByUser = await bookService.IsBookSavedAsync(new IsBookSavedRequestData()
                {
                    BookId = id,
                    UserId = userId
                });

                isBookPublishedByUser =
                    bookDetailsResponseData.PublisherId.ToLowerInvariant() == userId.ToLowerInvariant();
            }

            BookDetailsViewModel bookDetailsViewModel = new BookDetailsViewModel()
            {
                Id = bookDetailsResponseData.Id,
                Title = bookDetailsResponseData.Title,
                CoverImageUrl = bookDetailsResponseData.CoverImageUrl ?? DefaultCoverImageUrl,
                PublishedOn = bookDetailsResponseData.PublishedOn.ToString(DefaultPublishedDateFormat),
                Genre = bookDetailsResponseData.Genre,
                Publisher = publisherName,
                IsPublisher = isBookPublishedByUser,
                IsSaved = isBookSavedByUser
            };

            return View(bookDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            BookCreateInputModel inputModel = new BookCreateInputModel()
            {
                PublishedOn = DateTime.Today,
                Genres = await GetAllGenresDropdownListAsync()
            };

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel.Genres = await GetAllGenresDropdownListAsync();
                return View(inputModel);
            }

            bool isGenreValid = await genreService.GenreExistsByIdAsync(inputModel.GenreId);

            if (!isGenreValid)
            {
                return BadRequest("There was an error with your request! Try again!");
            }

            AddNewBookRequestData newBookRequestData = new AddNewBookRequestData()
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                CoverImageUrl = inputModel.CoverImageUrl,
                PublishedOn = inputModel.PublishedOn,
                GenreId = inputModel.GenreId,
                PublisherId = GetUserId()!
            };

            bool isBookCreated = await bookService.AddBookAsync(newBookRequestData);

            if (!isBookCreated)
            {
                ModelState.AddModelError(string.Empty, "There was an unexpected error with your request");
                inputModel.Genres = await GetAllGenresDropdownListAsync();

                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> MyBooks()
        {
            string userId = GetUserId()!;

            IEnumerable<GetMyBooksResponseData> myBooksResponseData = await bookService.GetMyBooksAsync(userId);

            IEnumerable<BookMyBooksViewModel> myBooksViewModel = myBooksResponseData
                .Select(b => new BookMyBooksViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    CoverImageUrl = b.CoverImageUrl ?? DefaultCoverImageUrl,
                    Genre = b.Genre
                })
                .ToArray();

            return View(myBooksViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyBooks([FromForm] int id, [FromQuery] string? returnUrl)
        {
            returnUrl ??= Url.Action(nameof(Index), "Book");

            bool bookExists = await bookService.ExistsByIdAsync(id);

            if (!bookExists)
            {
                return NotFound("The book you are trying to add does not exist");
            }

            string userId = GetUserId()!;

            bool isBookPublishedByUser = await bookService.IsBookPublisherAsync(new IsBookPublisherRequestData()
            {
                BookId = id,
                UserId = userId
            });

            if (isBookPublishedByUser)
            {
                return BadRequest("You cannot add your own book to your reading list");
            }

            AddToMyBooksRequestData addToMyBooksRequestData = new AddToMyBooksRequestData()
            {
                BookId = id,
                UserId = userId
            };

            bool bookAdded = await bookService.AddToMyBooksAsync(addToMyBooksRequestData);

            if (!bookAdded)
            {
                return BadRequest("There was an error with your request");
            }

            return Redirect(returnUrl!);
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

        private async Task<IEnumerable<GenreViewModel>> GetAllGenresDropdownListAsync()
        {
            IEnumerable<GetAllGenresResponseData> allGenresResponseData =
                await genreService.GetAllGenresAlphabeticallyAsync();

            IEnumerable<GenreViewModel> allGenresViewModel = allGenresResponseData
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToArray();

            return allGenresViewModel;
        }
    }
}
