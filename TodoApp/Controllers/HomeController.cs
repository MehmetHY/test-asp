using Microsoft.AspNetCore.Mvc;
using TodoData.UnitOfWork;
using TodoUtils.Utils;

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

        public IActionResult Index() => new RedirectUtil(this).GetAuthActionResult(View());
    }
}