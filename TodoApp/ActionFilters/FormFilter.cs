using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoApp.ActionFilters
{
    public class FormFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Controller controller = (Controller)context.Controller;
                var model = context.ActionArguments["model"];
                context.Result = controller.View(model);
            }
        }
    }
}
