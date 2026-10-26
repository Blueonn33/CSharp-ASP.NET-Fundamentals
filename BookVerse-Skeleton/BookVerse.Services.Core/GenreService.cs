using BookVerse.Data;
using BookVerse.Services.Core.Contracts;
using BookVerse.Services.Data.Genre.Response;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Services.Core
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext dbContext;

        public GenreService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetAllGenresResponseData>> GetAllGenresAlphabeticallyAsync()
        {
            IEnumerable<GetAllGenresResponseData> allGenresResponse = await dbContext.Genres
                .Select(g => new GetAllGenresResponseData()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Id)
                .ToArrayAsync();

            return allGenresResponse;
        }

        public async Task<bool> GenreExistsByIdAsync(int genreId)
        {
            bool genreExists = await dbContext.Genres
                .AnyAsync(g => g.Id == genreId);

            return genreExists;
        }
    }
}
