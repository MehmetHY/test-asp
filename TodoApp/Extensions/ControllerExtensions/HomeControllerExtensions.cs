using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class HomeControllerExtensions
    {
        public static IActionResult ProceedToHomePage(this HomeController controller)
        {
            var userId = controller.GetCurrentAccountId();
            var model = HomeViewModel.Factory.Create(controller.UnitOfWork, userId);

            return controller.View(model);
        }
    }
}
