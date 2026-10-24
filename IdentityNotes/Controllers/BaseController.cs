using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityNotes.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated => User.Identity?.IsAuthenticated ?? false;

        // Short implementation
        protected string? GetUserId()
            => User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //protected string? GetUserId()
        //{
        //    if (!IsUserAuthenticated)
        //    {
        //        return null;
        //    }

        //    return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //}
    }
}
