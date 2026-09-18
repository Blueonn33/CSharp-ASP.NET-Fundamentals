using GarageApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Data
{
    public class GarageAppDbContext : DbContext
    {
        public GarageAppDbContext(DbContextOptions<GarageAppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Garage> Garages { get; set; } = null!;
    }
}