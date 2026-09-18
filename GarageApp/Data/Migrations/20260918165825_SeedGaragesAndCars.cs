using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGaragesAndCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Central City", "Central City Garage" },
                    { 2, "Riverside", "Riverside Motors" },
                    { 3, "Mountainview", "Mountainview Auto" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarType", "GarageId", "IsAvailable", "Make", "Model", "ProductionMonth", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, true, "Toyota", "Corolla", 3, 2018 },
                    { 2, 1, 1, true, "Honda", "Civic", 5, 2020 },
                    { 3, 0, 2, false, "Ford", "Focus", null, 2016 },
                    { 4, 6, 3, true, "BMW", "Z4", 7, 2019 },
                    { 5, 2, 2, true, "Audi", "A5", 11, 2021 },
                    { 6, 4, 3, false, "Volkswagen", "Touran", 2, 2015 },
                    { 7, 8, 1, true, "Mercedes", "GLE", 9, 2022 },
                    { 8, 3, 2, true, "Fiat", "500", 6, 2014 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
