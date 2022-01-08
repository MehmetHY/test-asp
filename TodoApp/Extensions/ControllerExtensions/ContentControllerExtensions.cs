using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class ContentControllerExtensions
    {
        public static IActionResult ProceedToContentPage(this ContentController controller, int? categoryId)
        {
            var model = ContentViewModel.Factory.Create(controller.UnitOfWork, categoryId);

            return controller.View(model);
        }
    }
}
