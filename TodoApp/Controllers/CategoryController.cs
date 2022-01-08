using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Category;

namespace TodoApp.Controllers
{
    public class CategoryController : DataController
    {
        public CategoryController(AppService service) : base(service) {}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Create(CategoryViewModel? model)
        {

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Update(CategoryViewModel? model)
        {

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Delete(CategoryViewModel? model)
        {

        }
    }
}
