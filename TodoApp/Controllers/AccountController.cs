using Microsoft.AspNetCore.Mvc;
using TodoModels.ViewModels;
using TodoApp.ActionFilters;
using TodoApp.Adapters;
using TodoApp.Utils;
using TodoData.UnitOfWork;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public AccountController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AvoidRedundantSignFilter]
        public IActionResult Signin() => View();

        [HttpPost]
        public IActionResult Signin(SigninViewModel? model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }


        [AvoidRedundantSignFilter]
        public IActionResult Signup() => View();

        [HttpPost]
        public IActionResult Signup(SignupViewModel? model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = adapter.GetUser(model!);
            _unitOfWork.UserRepo.Add(user);
            this.SignIn(user);
            return RedirectToAction("Index", "Home");
        }

    }
}
