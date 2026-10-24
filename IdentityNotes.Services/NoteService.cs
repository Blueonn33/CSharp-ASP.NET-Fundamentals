using IdentityNotes.Data;
using IdentityNotes.Services.Contracts;
using IdentityNotes.Services.Data.Note.Request;
using IdentityNotes.Services.Data.Note.Response;

namespace IdentityNotes.Services
{
    public class NoteService(IdentityNotesDbContext _context) : INoteService
    {
        // Dependency injection works in separate class libraries
        // Using primary constructor
        public Task<IEnumerable<GetUserNotesResponseData>> GetAllUserNotesAsync(GetUserNotesRequestData requestData)
        {
            if (string.IsNullOrWhiteSpace(requestData.UserId))
            {
                throw new ArgumentException("UserId cannot be null or empty");
            }

            IEnumerable<GetUserNotesResponseData> userNotesResponseData = _context.Notes
                .Where(n => n.UserId.ToLower() == requestData.UserId.ToLower())
                .OrderBy(n => n.Id)
                .Select(n => new GetUserNotesResponseData()
                {
                    Id = n.Id,
                    Title = n.Title,
                    CreatedOn = n.CreatedOn
                });
        }
    }
}
