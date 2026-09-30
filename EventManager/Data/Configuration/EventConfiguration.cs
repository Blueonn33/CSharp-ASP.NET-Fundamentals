using EventManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public static readonly List<Event> Events = new List<Event>()
        {
            new Event()
            {
                Id = 1,
                Title = "ASP.NET Workshop",
                Description = "In this workshop will be discussed the fundamentals of ASP.NET",
                StartDate = new DateTime(2026, 10, 21),
                EndDate = new DateTime(2026, 10, 22),
                MaxParticipants = 12,
                CategoryId = 2
            },
            new Event()
            {
                Id = 2,
                Title = "ASP.NET Core Conference",
                Description = "A conference covering the fundamentals of ASP.NET Core MVC",
                StartDate = new DateTime(2026, 9, 11),
                EndDate = new DateTime(2026, 9, 12),
                MaxParticipants = 150,
                CategoryId = 1
            },
            new Event()
            {
                Id = 3,
                Title = "Web design seminar",
                Description = "Learn all the basics of web design in just 2 hours!",
                StartDate = new DateTime(2026, 5, 4),
                EndDate = new DateTime(2026, 5, 4),
                MaxParticipants = 35,
                CategoryId = 3
            },
            new Event()
            {
                Id = 4,
                Title = "Marleyan training",
                Description = "Become a marleyan warrior and defeat our enemies",
                StartDate = new DateTime(2026, 1, 10),
                EndDate = new DateTime(2030, 12, 30),
                MaxParticipants = 10,
                CategoryId = 4
            },
            new Event()
            {
                Id = 5,
                Title = "Scout regiment",
                Description = "Join the scout regiment to save the people from the titans",
                StartDate = new DateTime(2026, 1, 10),
                EndDate = new DateTime(2031, 12, 30),
                MaxParticipants = 50,
                CategoryId = 4
            }
        };
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(Events);
        }
    }
}
