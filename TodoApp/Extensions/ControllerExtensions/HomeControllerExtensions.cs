using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class HomeControllerExtensions
    {
        public static IActionResult ProceedToHomePage(this HomeController controller)
        {
            var userId = controller.GetCurrentAccountId();
            var model = controller.HomeViewModelFactory.CreateHomeViewModel(userId);
            return controller.View(model);
        }
    }
}
