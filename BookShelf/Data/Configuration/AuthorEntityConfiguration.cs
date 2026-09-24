using BookShelf.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Data.Configuration
{
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public readonly IEnumerable<Author> SeedAuthors = new List<Author>()
        {
            new Author
            {
                Id = 1,
                Name = "Victor Hugo",
                Country = "France"
            },
            new Author
            {
                Id = 2,
                Name = "George Orwell"
            },
            new Author
            {
                Id = 3,
                Name = "Алеко Константинов",
                Country = "България"
            }
        };

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(SeedAuthors);
        }
    }
}
