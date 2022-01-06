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

            return model == null ?
                RedirectToAction("Signin", "Account") : View(model);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromForm] HomeViewModel? model)
        {
            if (model == null)
                return RedirectToAction(nameof(Index));

            if (ModelState.Valid(model.CreateCategoryModel, _unitOfWork))
                return Ok(model.CreateCategoryModel.NewCategoryName);
            
            return View(nameof(Index), model);
        }
    }
}