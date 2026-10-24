using Microsoft.AspNetCore.Mvc;

namespace IdentityNotes.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated => User.Identity?.IsAuthenticated ?? false;

        // Short implementation
        protected string? GetUserId()
            => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        //protected string? GetUserId()
        //{
        //    if (!IsUserAuthenticated)
        //    {
        //        return null;
        //    }

        //    return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        //}
    }
}
