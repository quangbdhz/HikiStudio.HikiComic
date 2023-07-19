using HikiComic.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HikiComic.Management.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var token = context.HttpContext.Request.Cookies["TOKEN"];
            var isLogin = User?.Identity?.IsAuthenticated;

            if (isLogin is null || isLogin == false || String.IsNullOrEmpty(token) || String.IsNullOrEmpty(sessions))
                context.Result = new RedirectToActionResult("Login", "Auth", null);

            base.OnActionExecuting(context);
        }
    }
}
