using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoApp.ActionFilters
{
    public class AuthUserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
