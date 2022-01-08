using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Extensions.ControllerExtensions;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class CategoryController : DataController
    {
        public CategoryController(AppService service) : base(service) {}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Create([FromForm] CategoryViewModel model) => 
            this.ProceedToCreateCategory(model);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Update(CategoryViewModel? model) =>
            this.ProceedToUpdateCategory(model);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Delete(CategoryViewModel model) =>
            this.ProceedToDeleteCategory(model);
    }
}
