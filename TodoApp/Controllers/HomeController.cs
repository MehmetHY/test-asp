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

            Dictionary<string, string>? errorDictionary;

            if (TempData.ContainsKey(nameof(errorDictionary)))
            {
                errorDictionary = TempData[nameof(errorDictionary)] as Dictionary<string, string>;

                if (errorDictionary != null)
                    foreach (var item in errorDictionary)
                        ModelState.AddModelError(item.Key, item.Value);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory([FromForm(Name = "CreateCategoryModel")] CreateCategoryViewModel? model)
        {
            if (model == null)
                return RedirectToAction(nameof(Index));

            if (ModelState.Valid(model, _unitOfWork))
                return Ok(model.NewCategoryName);


            var errorDictionary = new Dictionary<string, string>();

            foreach (var state in ModelState)
            {
                var propertyName = state.Key;

                foreach (var error in state.Value.Errors)
                    errorDictionary.Add(propertyName, error.ErrorMessage);

            }

            TempData[nameof(errorDictionary)] = errorDictionary;



            return RedirectToAction(nameof(Index));
        }
    }
}