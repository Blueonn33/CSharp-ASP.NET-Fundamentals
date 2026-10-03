using GameZone.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public static readonly IEnumerable<Genre> InitialGenres = new List<Genre>()
        {
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Adventure" },
            new Genre { Id = 3, Name = "Fighting" },
            new Genre { Id = 4, Name = "Sports" },
            new Genre { Id = 5, Name = "Racing" },
            new Genre { Id = 6, Name = "Strategy" }
        };

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(g => g.Name)
                .IsUnique();

            builder.HasMany(g => g.Games)
                   .WithOne(gm => gm.Genre)
                   .HasForeignKey(gm => gm.GenreId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(InitialGenres);
        }
    }
}
