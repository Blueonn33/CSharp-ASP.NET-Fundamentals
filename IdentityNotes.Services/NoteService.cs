using IdentityNotes.Data;
using IdentityNotes.Services.Contracts;
using IdentityNotes.Services.Data.Note.Request;
using IdentityNotes.Services.Data.Note.Response;
using Microsoft.EntityFrameworkCore;

namespace IdentityNotes.Services
{
    public class NoteService(IdentityNotesDbContext _context) : INoteService
    {
        // Dependency injection works in separate class libraries
        // Using primary constructor
        public async Task<IEnumerable<GetUserNotesResponseData>> GetAllUserNotesAsync(GetUserNotesRequestData requestData)
        {
            if (string.IsNullOrWhiteSpace(requestData.UserId))
            {
                throw new ArgumentException("UserId cannot be null or empty");
            }

            IEnumerable<GetUserNotesResponseData> userNotesResponseData = await _context.Notes
                .Where(n => n.UserId.ToLower() == requestData.UserId.ToLower())
                .Select(n => new GetUserNotesResponseData()
                {
                    Id = n.Id,
                    Title = n.Title,
                    CreatedOn = n.CreatedOn
                })
                .OrderBy(n => n.Id)
                .Skip(requestData.SkipEntries)
                .Take(requestData.TakeEntries)
                .ToArrayAsync();

            return userNotesResponseData;
        }
    }
}
