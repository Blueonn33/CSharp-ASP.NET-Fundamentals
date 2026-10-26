using BookVerse.Data;
using BookVerse.DataModels;
using BookVerse.Services.Core.Contracts;
using BookVerse.Services.Data.Book.Request;
using BookVerse.Services.Data.Book.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookVerse.Services.Core
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<BookService> logger;

        public BookService(ApplicationDbContext dbContext, ILogger<BookService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<bool> AddBookAsync(AddNewBookRequestData requestData)
        {
            Book newBook = new Book()
            {
                Title = requestData.Title,
                Description = requestData.Description,
                CoverImageUrl = requestData.CoverImageUrl,
                PublisherId = requestData.PublisherId,
                PublishedOn = requestData.PublishedOn,
                GenreId = requestData.GenreId
            };

            try
            {
                await dbContext.Books.AddAsync(newBook);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured while adding a new book");
            }

            return false;
        }

        public async Task<IEnumerable<GetAllBooksResponseData>> GetAllBooksAsync()
        {
            IEnumerable<GetAllBooksResponseData> allBooksResponse = await dbContext.Books
                .Select(b => new GetAllBooksResponseData()
                {
                    Id = b.Id,
                    Title = b.Title,
                    CoverImageUrl = b.CoverImageUrl,
                    GenreName = b.Genre.Name,
                    PublisherId = b.PublisherId
                })
                .OrderBy(b => b.Title)
                .ThenBy(b => b.GenreName)
                .ToArrayAsync();

            return allBooksResponse;
        }

        public async Task<GetUsersListedBookResponseData> GetUsersIdsListedBookByIdAsync(GetUsersListedBookRequestData requestData)
        {
            IEnumerable<string> userIdsListedBook = await dbContext.UsersBooks
                .Where(ub => ub.BookId == requestData.BookId)
                .Select(ub => ub.UserId)
                .ToArrayAsync();

            GetUsersListedBookResponseData usersListedBookResponse = new GetUsersListedBookResponseData()
            {
                UsersListedIds = userIdsListedBook
            };

            return usersListedBookResponse;
        }

        public async Task<GetBookDetailsResponseData?> GetBookByIdAsync(int id)
        {
            Book? book = await dbContext.Books
                .Include(b => b.Genre)
                .SingleOrDefaultAsync(b => b.Id == id);

            GetBookDetailsResponseData? bookDetailsResponse = null;

            if (book != null)
            {
                bookDetailsResponse = new GetBookDetailsResponseData()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublishedOn = book.PublishedOn,
                    Genre = book.Genre.Name,
                    PublisherId = book.PublisherId
                };
            }

            return bookDetailsResponse;
        }

        public async Task<bool> IsBookSavedAsync(IsBookSavedRequestData requestData)
        {
            bool isBookSavedByUser = await dbContext.UsersBooks
                .AnyAsync(ub => ub.BookId == requestData.BookId &&
                                ub.UserId.ToLower() == requestData.UserId.ToLower());

            return isBookSavedByUser;
        }

        public async Task<bool> IsBookPublisherAsync(IsBookPublisherRequestData requestData)
        {
            bool isBookPublishedByUser = await dbContext.Books
                .Where(b => b.Id == requestData.BookId)
                .AnyAsync(b => b.PublisherId.ToLower() == requestData.UserId.ToLower());

            return isBookPublishedByUser;
        }

        public async Task<IEnumerable<GetMyBooksResponseData>> GetMyBooksAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return new List<GetMyBooksResponseData>();
            }

            IEnumerable<GetMyBooksResponseData> myBooksResponse = await dbContext.UsersBooks
                .Where(ub => ub.UserId.ToLower() == userId.ToLower())
                .Select(ub => ub.Book)
                .Select(b => new GetMyBooksResponseData()
                {
                    Id = b.Id,
                    Title = b.Title,
                    CoverImageUrl = b.CoverImageUrl,
                    Genre = b.Genre.Name
                })
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Genre)
                .ToArrayAsync();

            return myBooksResponse;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool bookExists = await dbContext.Books
                .AnyAsync(b => b.Id == id);

            return bookExists;
        }

        public async Task<bool> AddToMyBooksAsync(AddToMyBooksRequestData requestData)
        {
            bool bookExists = await ExistsByIdAsync(requestData.BookId);

            if (!bookExists)
            {
                logger.LogWarning("Book with ID {BookId} does not exist", requestData.BookId);
                return false;
            }

            bool isBookPublisher = await IsBookPublisherAsync(new IsBookPublisherRequestData()
            {
                BookId = requestData.BookId,
                UserId = requestData.UserId
            });

            if (isBookPublisher)
            {
                logger.LogWarning("User with ID {UserId} is the publisher of this book", requestData.UserId);
                return false;
            }

            bool isBookAlreadySaved = await IsBookSavedAsync(new IsBookSavedRequestData()
            {
                BookId = requestData.BookId,
                UserId = requestData.UserId
            });

            if (!isBookAlreadySaved)
            {
                UserBook newUserBook = new UserBook()
                {
                    BookId = requestData.BookId,
                    UserId = requestData.UserId
                };

                try
                {
                    await dbContext.UsersBooks.AddAsync(newUserBook);
                    await dbContext.SaveChangesAsync();

                    return true;
                }
                catch (Exception e)
                {
                    logger.LogError(e, "An error occured while adding the book with ID {BookId}", requestData.BookId);
                }

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
