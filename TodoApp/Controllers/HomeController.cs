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
            View(_hvmFactory.CreateHomeViewModel(this, string.Empty));

        [Route("[Action]/{Category}")]
        public IActionResult Category([FromRoute(Name = "Category")] string? category)
        {
            var model = _hvmFactory.CreateHomeViewModel(this, category);
            return model == null ?
                RedirectToAction(nameof(Index)) : View(nameof(Index), model);
        }
    }
}