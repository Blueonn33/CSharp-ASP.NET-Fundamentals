using BookVerse.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookVerse.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public static IEnumerable<Book> DefaultBooks
            => new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "Whispers of the Mountain",
                    Description =
                        "Emily Harper (released 2015): A quiet village, a hidden path, and a choice that changes everything.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/9187Qn8bL6L._UF1000,1000_QL80_.jpg",
                    PublisherId = UserConfiguration.DefaultUser.Id,
                    PublishedOn = DateTime.Now,
                    GenreId = 1,
                    IsDeleted = false
                },
                new Book
                {
                    Id = 2,
                    Title = "Shadows in the Fog",
                    Description =
                        "Michael Turner (released: 2017): An investigator follows a trail of secrets through a city shrouded in mystery.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/719g0mh9f2L._UF1000,1000_QL80_.jpg",
                    PublisherId = UserConfiguration.DefaultUser.Id,
                    PublishedOn = DateTime.Now,
                    GenreId = 2,
                    IsDeleted = false
                },
                new Book
                {
                    Id = 3,
                    Title = "Letters from the Heart",
                    Description =
                        "Sarah Collins (released 2020): A touching story about love, distance, and the power of written words.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/71zwodP9GzL._UF1000,1000_QL80_.jpg",
                    PublisherId = UserConfiguration.DefaultUser.Id,
                    PublishedOn = DateTime.Now,
                    GenreId = 3,
                    IsDeleted = false
                }
            };

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(DefaultBooks);
        }
    }
}
