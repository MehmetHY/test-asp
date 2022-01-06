using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class HomeController : Controller
    {
        private readonly HomeViewModelFactory _hvmFactory;

        public HomeController(AppService appService)
        {
            _hvmFactory =  appService.HomeViewModelFactory;
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

        }
    }
}