using Microsoft.AspNetCore.Mvc;
using TodoApp.ViewModels;
using TodoApp.ActionFilters;
using TodoApp.Extensions.Validation;
using TodoApp.Extensions;
using TodoData.UnitOfWork;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UnitOfWork _unitOfWork;
        public AccountController(AppService service) : base(service)
        {
            _unitOfWork = service.UnitOfWork;
        }

        [AvoidRedundantSignFilter]
        public IActionResult Signin() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signin(SigninViewModel? model)
        {
            if (!ModelState.Valid(model, _unitOfWork))
                return View(model);

            this.Signin(model!, _unitOfWork);
            return RedirectToAction("Index", "Home");
        }


        [AvoidRedundantSignFilter]
        public IActionResult Signup() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(SignupViewModel? model)
        {
            if (!ModelState.Valid(model, _unitOfWork))
                return View(model);

            this.SignUp(model!, _unitOfWork);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            this.Signout();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
