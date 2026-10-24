using Microsoft.AspNetCore.Mvc;

namespace IdentityNotes.Controllers
{
    public class NoteController : Controller
    {
        public async Task<IActionResult> MyNotes()
        {
            return View();
        }
    }
}
