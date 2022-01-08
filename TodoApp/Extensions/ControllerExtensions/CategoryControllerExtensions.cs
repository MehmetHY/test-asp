using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class CategoryControllerExtensions
    {
        public static IActionResult ProceedToCreateCategory(this CategoryController controller, CategoryViewModel? model)
        {

        }
    }
}
