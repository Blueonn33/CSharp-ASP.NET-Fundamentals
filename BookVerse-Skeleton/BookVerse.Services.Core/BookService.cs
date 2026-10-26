using BookVerse.Data;
using BookVerse.Services.Core.Contracts;
using BookVerse.Services.Data.Book.Request;
using BookVerse.Services.Data.Book.Response;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Services.Core
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext dbContext;

        public BookService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
