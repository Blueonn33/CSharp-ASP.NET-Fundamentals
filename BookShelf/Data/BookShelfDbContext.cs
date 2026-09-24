using BookShelf.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Data
{
    public class BookShelfDbContext : DbContext
    {
        public BookShelfDbContext(DbContextOptions<BookShelfDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<Author> Authors
        {
            get; set;
        } = null!;

        public virtual DbSet<Book> Books
        {
            get; set;
        } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
