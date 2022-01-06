using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions;
using TodoApp.ViewModels;
using TodoData.UnitOfWork;
using TodoApp.Extensions.Validation;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class CategoryController : Controller
    {
        private readonly CategoryViewModelFactory _cvmFactory;
        private readonly UnitOfWork _unitOfWork;

        public CategoryController(AppService appService)
        {
            _cvmFactory = appService.CategoryViewModelFactory;
            _unitOfWork = appService.UnitOfWork;
        }

        public IActionResult Index(int? categoryId)
        {
            var userId = this.GetCurrentAccountId();
            var model = _cvmFactory.CreateCategoryViewModel(userId, categoryId);

            return model == null ?
                RedirectToAction("Index", "Home") : View(model);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromForm] HomeViewModel? model)
        {
            if (model == null)
                return RedirectToAction("Index", "Home");

            if (ModelState.Valid(model.CreateCategoryModel, _unitOfWork))
                return Ok(model.CreateCategoryModel.NewCategoryName);

            return View(nameof(Index), model);
        }
    }
}
