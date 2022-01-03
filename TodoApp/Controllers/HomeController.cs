using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.Models;
using TodoData.UnitOfWork;
using TodoModels.Models;

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

        public IActionResult Index()
        {
            UserModel? user = _unitOfWord.UserRepo.Get(1);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}