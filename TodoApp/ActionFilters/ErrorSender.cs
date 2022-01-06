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

            var errorDictionary = new Dictionary<string, IEnumerable<string>>();
            
            foreach (var state in modelState)
            {
                string propertyName = state.Key;
                var errorMessages = new List<string>();
            
                foreach (var error in state.Value.Errors)
                    errorMessages.Add(error.ErrorMessage);

                if (errorMessages.Count > 0)
                    errorDictionary.Add(propertyName, errorMessages);
            }

            controller!.TempData[nameof(errorDictionary)] = errorDictionary;
        }
    }
}
