using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoApp.Utils;

namespace TodoApp.ActionFilters
{
    
    public class AuthUserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.IsSignedIn())
                context.Result = new RedirectToActionResult("Signin", "Account", null);
        }
    }
}
