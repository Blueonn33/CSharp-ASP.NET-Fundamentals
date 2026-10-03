using GameZone.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class GameZoneDbContext : DbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options) : base(options) { }

        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameZoneDbContext).Assembly);
        }
    }
}
