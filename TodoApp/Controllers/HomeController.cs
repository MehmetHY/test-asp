using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;

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

        public IActionResult Index() =>
            View(_hvmFactory.CreateHomeViewModel(this));
    }
}