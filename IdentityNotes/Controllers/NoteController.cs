using IdentityNotes.Web.ViewModels.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityNotes.Controllers
{
    [Authorize]
    public class NoteController : BaseController
    {
        public async Task<IActionResult> MyNotes()
        {
            return View(new List<NoteListItemViewModel>());
        }
    }
}
