using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Models.Type;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events
        {
            get;
            set;
        } = null!;

        public virtual DbSet<Type> Types
        {
            get;
            set;
        } = null!;

        public virtual DbSet<EventParticipant> EventsParticipants
        {
            get;
            set;
        } = null!;

        public virtual DbSet<ApplicationUser> ApplicationUsers
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.HelperId, ep.EventId });
            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(ep => ep.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "sample-organizer",
                UserName = "sample-organizer",
                NormalizedUserName = "SAMPLE-ORGANIZER",
                SecurityStamp = "sample-organizer-security-stamp"
            });

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Animal Shelter",
                    Description = "Help care for animals at the local shelter.",
                    OrganizerId = "sample-organizer",
                    CreatedOn = new DateTime(2025, 1, 1, 9, 0, 0),
                    Start = new DateTime(2025, 2, 1, 10, 0, 0),
                    End = new DateTime(2025, 2, 1, 12, 0, 0),
                    TypeId = 1
                },
                new Event
                {
                    Id = 2,
                    Name = "Board Games",
                    Description = "Join us for an afternoon of board games.",
                    OrganizerId = "sample-organizer",
                    CreatedOn = new DateTime(2025, 1, 2, 9, 0, 0),
                    Start = new DateTime(2025, 2, 8, 14, 0, 0),
                    End = new DateTime(2025, 2, 8, 17, 0, 0),
                    TypeId = 2
                },
                new Event
                {
                    Id = 3,
                    Name = "Community Talk",
                    Description = "Discuss ideas for improving our community.",
                    OrganizerId = "sample-organizer",
                    CreatedOn = new DateTime(2025, 1, 3, 9, 0, 0),
                    Start = new DateTime(2025, 2, 15, 16, 0, 0),
                    End = new DateTime(2025, 2, 15, 18, 0, 0),
                    TypeId = 3
                });
        }
    }
}