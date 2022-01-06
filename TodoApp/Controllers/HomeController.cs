using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions;
using TodoApp.ViewModels;
using TodoApp.Extensions.Validation;
using TodoData.UnitOfWork;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class HomeController : Controller
    {
        private readonly HomeViewModelFactory _hvmFactory;
        private readonly UnitOfWork _unitOfWork;

        public HomeController(AppService appService)
        {
            _hvmFactory = appService.HomeViewModelFactory;
            _unitOfWork = appService.UnitOfWork;
        }

        public IActionResult Index()
        {
            var userId = this.GetCurrentAccountId();
            var model = _hvmFactory.CreateHomeViewModel(userId);
            
            if (model == null)
                return RedirectToAction("Signin", "Account");

            if (TempData.ContainsKey("Errors"))
            {
                var errors = (Dictionary<string, string>)TempData["Errors"]!;
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory([FromForm(Name = "CreateCategoryModel")] CreateCategoryViewModel? model)
        {
            if (model == null)
                return RedirectToAction(nameof(Index));

            if (ModelState.Valid(model, _unitOfWork, out var errors))
                return Ok(model.NewCategoryName);

            TempData["Errors"] = errors;

            return RedirectToAction(nameof(Index));
        }
    }
}