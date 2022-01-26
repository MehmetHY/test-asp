using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoApp.ActionFilters
{
    public class ErrorSender : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            var controller = context.Controller as Controller;
            var modelState = controller?.ViewData.ModelState;
            
            if (modelState == null)
                return;

            var errorDictionary = new Dictionary<string, string>();
            
            foreach (var state in modelState)
            {
                var propertyName = state.Key;
            
                foreach (var error in state.Value.Errors)
                    errorDictionary.Add(propertyName, error.ErrorMessage);

            }

            controller!.TempData[nameof(errorDictionary)] = errorDictionary;
        }
    }
}
