using IdentityNotes.Services.Data.Note.Request;
using IdentityNotes.Services.Data.Note.Response;

namespace IdentityNotes.Services.Contracts
{
    public interface INoteService
    {
        // Service Contract Definition: Service Name + Request Data + Response Data
        Task<IEnumerable<GetUserNotesResponseData>> GetAllUserNotesAsync(GetUserNotesRequestData requestData);
    }
}
