using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ParticipantName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conference" },
                    { 2, "Workshop" },
                    { 3, "Seminar" },
                    { 4, "Training" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Description", "EndDate", "MaxParticipants", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 2, "In this workshop will be discussed the fundamentals of ASP.NET", new DateTime(2026, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Workshop" },
                    { 2, 1, "A conference covering the fundamentals of ASP.NET Core MVC", new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Conference" },
                    { 3, 3, "Learn all the basics of web design in just 2 hours!", new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web design seminar" },
                    { 4, 4, "Become a marleyan warrior and defeat our enemies", new DateTime(2030, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marleyan training" },
                    { 5, 4, "Join the scout regiment to save the people from the titans", new DateTime(2031, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scout regiment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
