using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class HomeController : Controller
    {
        private readonly HomeViewModelFactory _homeViewModelFactory;

        public HomeController(AppService appService)
        {
            _homeViewModelFactory = appService.HomeViewModelFactory;
        }

        [ErrorReceiver]
        public IActionResult Index()
        {
            var userId = this.GetCurrentAccountId();
            var model = _homeViewModelFactory.CreateHomeViewModel(userId);
            
            return View(model);
        }
    }
}