using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.Extensions.ControllerExtensions;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class HomeController : DataController
    {
        public HomeController(AppService service) : base(service) {}

        [ErrorReceiver]
        public IActionResult Index() => this.ProceedToHomePage();
    }
}