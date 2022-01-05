using Microsoft.AspNetCore.Mvc;
using TodoData.UnitOfWork;
using TodoApp.ActionFilters;
using TodoApp.Extensions;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, UnitOfWork unitOfWord)
        {
            _logger = logger;
            _unitOfWork = unitOfWord;
        }

        public IActionResult Index() 
        {
            var model = new HomeViewModel();
            int userId = this.GetCurrentAccountId()!.Value;
            model.Load(userId, _unitOfWork);
            return View(model);
        }
    }
}