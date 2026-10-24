using IdentityNotes.Services.Contracts;
using IdentityNotes.Services.Data.Note.Request;
using IdentityNotes.Services.Data.Note.Response;
using IdentityNotes.Web.ViewModels.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static IdentityNotes.Common.ApplicationConstants;

namespace IdentityNotes.Controllers
{
    [Authorize]
    public class NoteController(INoteService _noteService) : BaseController
    {
        public async Task<IActionResult> MyNotes()
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            GetUserNotesRequestData requestData = new GetUserNotesRequestData()
            {
                UserId = userId,
                SkipEntries = DefaultSkipEntries, // No pagination implemented yet
                TakeEntries = DefaultTakeEntries // No pagination implemented yet
            };

            try
            {
                IEnumerable<GetUserNotesResponseData> getUserNotesResponseData = await _noteService.GetAllUserNotesAsync(requestData);

                IEnumerable<NoteListItemViewModel> userNotesViewModel = getUserNotesResponseData
                    .OrderByDescending(n => n.CreatedOn)
                    .ThenBy(n => n.Title)
                    .Select(n => new NoteListItemViewModel()
                    {
                        Id = n.Id,
                        Title = n.Title,
                        CreatedOn = n.CreatedOn.ToString(DateTimeFormat)
                    })
                    .ToArray();

                return View(userNotesViewModel);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
