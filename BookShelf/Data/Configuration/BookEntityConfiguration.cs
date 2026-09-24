using BookShelf.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Data.Configuration
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public readonly IEnumerable<Book> SeedBooks = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Les Misérables",
                Year = 1862,
                AuthorId = 1
            },
            new Book
            {
                Id = 2,
                Title = "1984",
                Year = 1949,
                AuthorId = 2
            },
            new Book
            {
                Id = 3,
                Title = "Бай Ганьо",
                Year = 1895,
                AuthorId = 3
            },
            new Book
            {
                Id = 4,
                Title = "До Чикаго и назад",
                Year = 1894,
                AuthorId = 3
            }
        };

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(SeedBooks);
        }
    }
}
