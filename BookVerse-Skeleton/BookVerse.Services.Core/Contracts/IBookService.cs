using BookVerse.ViewModels;
using BookVerse.ViewModels.Book;
using BookVerse.ViewModels.Genre;

namespace BookVerse.Services.Core.Contracts
{
    public interface IBookService
    {
        Task AddBookAsync(BookCreateViewModel model, string publisherId);

        Task AddToMyBooksAsync(int id, string userId);

        Task DeleteBookAsync(int id, string userId);

        Task<IEnumerable<BookIndexViewModel>> GetAllBooksAsync(string? userId);


        Task<BookIndexViewModel?> GetBookByIdAsync(int id);

        Task<BookDetailsViewModel> GetBookDetailsByIdAsync(int id);

        Task<bool> IsBookSavedAsync(int bookId, string userId);

        Task<bool> IsBookPublisherAsync(int bookId, string userId);

        Task<BookCreateViewModel> GetBookCreateViewModelAsync();


        Task<IEnumerable<BookMyBooksViewModel>> GetMyBooksAsync(string userId);


        Task RemoveFromMyBooksAsync(int id, string userId);

        Task<BookEditViewModel> GetBookForEditAsync(int id, string userId);

        Task EditBookAsync(BookEditViewModel model, string userId);

        Task<IEnumerable<GenreViewModel>> GetAllGenresAsync();


        Task<BookDeleteViewModel> GetBookDeleteDetailsAsync(int id, string userId);
    }
}
