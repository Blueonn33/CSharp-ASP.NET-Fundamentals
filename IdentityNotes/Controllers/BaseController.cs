using Microsoft.AspNetCore.Mvc;

namespace IdentityNotes.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated => User.Identity?.IsAuthenticated ?? false;
    }
}
