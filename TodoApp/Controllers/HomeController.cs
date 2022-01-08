using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions.ControllerExtensions;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class HomeController : BaseController
    {
        public HomeViewModelFactory HomeViewModelFactory { get; private set; }

        public HomeController(AppService service) : base(service)
        {
            HomeViewModelFactory = service.HomeViewModelFactory;
        }

        [ErrorReceiver]
        public IActionResult Index() => this.ProceedToHomePage();
    }
}