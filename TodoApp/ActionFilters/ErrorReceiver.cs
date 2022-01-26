using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoApp.ActionFilters
{
    public class ErrorReceiver : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var controller = context.Controller as Controller;
            var modelState = controller?.ViewData.ModelState;

            if (modelState == null)
                return;

            Dictionary<string, string>? errorDictionary;

            if (!controller!.TempData.ContainsKey(nameof(errorDictionary)))
                return;

            errorDictionary = controller.TempData[nameof(errorDictionary)]
                as Dictionary<string, string>;

            if (errorDictionary == null || errorDictionary.Count < 1)
                return;

            foreach (var item in errorDictionary)
                modelState!.AddModelError(item.Key, item.Value);

            controller.TempData.Remove(nameof(errorDictionary));
        }
    }
}
