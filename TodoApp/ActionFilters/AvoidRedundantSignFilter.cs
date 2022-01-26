using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoApp.Extensions;

namespace TodoApp.ActionFilters
{
    public class AvoidRedundantSignFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Controller controller = (Controller)context.Controller; 
            if (context.HttpContext.Session.IsSignedIn())
                context.Result = controller.RedirectToHomePage();
        }
    }
}
