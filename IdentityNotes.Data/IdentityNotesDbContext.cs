using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityNotes.Data
{
    public class IdentityNotesDbContext(DbContextOptions<IdentityNotesDbContext> options) : IdentityDbContext(options)
    {
    }
}
