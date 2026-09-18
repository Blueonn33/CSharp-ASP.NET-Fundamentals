using GarageApp.Data.Models;
using GarageApp.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configuration
{
    public class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        private static readonly List<Garage> Garages =
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

        public static readonly List<Car> Cars =
        [
            new Car
            {
                Id = 1,
                Make = "Toyota",
                Model = "Corolla",
                ProductionMonth = 3,
                Year = 2018,
                CarType = CarType.Sedan,
                IsAvailable = true,
                GarageId = 1
            },
            new Car
            {
                Id = 2,
                Make = "Honda",
                Model = "Civic",
                ProductionMonth = 5,
                Year = 2020,
                CarType = CarType.Sedan,
                IsAvailable = true,
                GarageId = 1
            },
            new Car
            {
                Id = 3,
                Make = "Ford",
                Model = "Focus",
                ProductionMonth = null,
                Year = 2016,
                CarType = CarType.Hatchback,
                IsAvailable = false,
                GarageId = 2
            },
            new Car
            {
                Id = 4,
                Make = "BMW",
                Model = "Z4",
                ProductionMonth = 7,
                Year = 2019,
                CarType = CarType.Roadster,
                IsAvailable = true,
                GarageId = 3
            },
            new Car
            {
                Id = 5,
                Make = "Audi",
                Model = "A5",
                ProductionMonth = 11,
                Year = 2021,
                CarType = CarType.Coupe,
                IsAvailable = true,
                GarageId = 2
            },
            new Car
            {
                Id = 6,
                Make = "Volkswagen",
                Model = "Touran",
                ProductionMonth = 2,
                Year = 2015,
                CarType = CarType.Tourer,
                IsAvailable = false,
                GarageId = 3
            },
            new Car
            {
                Id = 7,
                Make = "Mercedes",
                Model = "GLE",
                ProductionMonth = 9,
                Year = 2022,
                CarType = CarType.SUV,
                IsAvailable = true,
                GarageId = 1
            },
            new Car
            {
                Id = 8,
                Make = "Fiat",
                Model = "500",
                ProductionMonth = 6,
                Year = 2014,
                CarType = CarType.Cabriolet,
                IsAvailable = true,
                GarageId = 2
            }
        ];

        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            throw new NotImplementedException();
        }
    }
}