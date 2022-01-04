using Microsoft.AspNetCore.Mvc;
using TodoData.UnitOfWork;
using TodoApp.ActionFilters;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _unitOfWord;

        public HomeController(ILogger<HomeController> logger, UnitOfWork unitOfWord)
        {
            _logger = logger;
            _unitOfWord = unitOfWord;
        }

        [ServiceFilter(typeof(AuthUserFilter))]
        public IActionResult Index() => View();
    }
}