using EventManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public static readonly List<Category> Categories = new List<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "Conference"
            },
            new Category()
            {
                Id = 2,
                Name = "Workshop"
            },
            new Category()
            {
                Id = 3,
                Name = "Seminar"
            },
            new Category()
            {
                Id = 4,
                Name = "Training"
            }
        };

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(Categories);
        }
    }
}
