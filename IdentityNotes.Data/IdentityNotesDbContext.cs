using IdentityNotes.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityNotes.Data
{
    public class IdentityNotesDbContext(DbContextOptions<IdentityNotesDbContext> options) : IdentityDbContext(options)
    {
        public virtual DbSet<Note> Notes { get; set; } = null!;
    }
}
