using BookVerse.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<UserBook> UsersBooks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Thriller" },
                new Genre { Id = 3, Name = "Romance" },
                new Genre { Id = 4, Name = "Sci‑Fi" },
                new Genre { Id = 5, Name = "History" },
                new Genre { Id = 6, Name = "Non‑Fiction" }
            );

            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Whispers of the Mountain",
                    Description = "Emily Harper (released 2015): A quiet village, a hidden path, and a choice that changes everything.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/9187Qn8bL6L._UF1000,1000_QL80_.jpg",
                    PublisherId = defaultUser.Id,
                    PublishedOn = DateTime.Now,
                    GenreId = 1,
                    IsDeleted = false
                },
                new Book
                {
                    Id = 2,
                    Title = "Shadows in the Fog",
                    Description = "Michael Turner (released: 2017): An investigator follows a trail of secrets through a city shrouded in mystery.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/719g0mh9f2L._UF1000,1000_QL80_.jpg",
                    PublisherId = defaultUser.Id,
                    PublishedOn = DateTime.Now,
                    GenreId = 2,
                    IsDeleted = false
                },
                new Book
                {
                    Id = 3,
                    Title = "Letters from the Heart",
                    Description = "Sarah Collins (released 2020): A touching story about love, distance, and the power of written words.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/71zwodP9GzL._UF1000,1000_QL80_.jpg",
                    PublisherId = defaultUser.Id,
                    PublishedOn = DateTime.Now,
                    GenreId = 3,
                    IsDeleted = false
                }
            );

        }
    }
}
