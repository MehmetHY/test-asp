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

        [ErrorReceiver]
        public IActionResult Index(int? categoryId)
        {
            var userId = this.GetCurrentAccountId();
            var model = _cvmFactory.CreateCategoryViewModel(userId, categoryId);

            return model == null ?
                RedirectToAction("Index", "Home") : View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Create([FromForm(Name = "CreateCategoryModel")] CreateCategoryViewModel? model)
        {
            if (ModelState.Valid(model, _unitOfWork))
                return Ok(model!.NewCategoryName);

            return model!.FromHome ? 
                RedirectToAction("Index", "Home") :
                RedirectToAction(nameof(Index), new { categoryId = model.BaseCategoryId });
        }
    }
}
