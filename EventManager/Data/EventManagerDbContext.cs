using EventManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class EventManagerDbContext : DbContext
    {
        public EventManagerDbContext(DbContextOptions<EventManagerDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public virtual DbSet<Event> Events
        {
            get; set;
        } = null!;

        public virtual DbSet<Category> Categories
        {
            get; set;
        } = null!;

        public virtual DbSet<Registration> Registrations
        {
            get; set;
        } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventManagerDbContext).Assembly);
        }
    }
}
