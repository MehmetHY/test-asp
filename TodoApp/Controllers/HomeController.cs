using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class HomeController : BaseController
    {
        private readonly HomeViewModelFactory _homeViewModelFactory;

        public HomeController(AppService service) : base(service)
        {
            _homeViewModelFactory = service.HomeViewModelFactory;
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