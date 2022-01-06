using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class CategoryController : Controller
    {
        private readonly CategoryViewModelFactory _cvmFactory;

        public CategoryController(AppService appService)
        {
            _cvmFactory = appService.CategoryViewModelFactory;
        }

        public IActionResult Index(int? categoryId)
        {
            var userId = this.GetCurrentAccountId();
            var model = _cvmFactory.CreateCategoryViewModel(userId, categoryId);

            return model == null ?
                RedirectToAction("Index", "Home") : View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm(Name = "viewModel")] CategoryViewModel? viewModel)
        {
            return Ok();
        }
    }
}
