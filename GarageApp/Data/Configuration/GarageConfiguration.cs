using GarageApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configuration
{
    public class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        public static readonly List<Garage> Garages =
        [
            new Garage
            {
                Id = 1,
                Name = "Central City Garage",
                Location = "Central City"
            },
            new Garage
            {
                Id = 2,
                Name = "Riverside Motors",
                Location = "Riverside"
            },
            new Garage
            {
                Id = 3,
                Name = "Mountainview Auto",
                Location = "Mountainview"
            }
        ];

        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.HasData(Garages);
        }
    }
}