using Microsoft.AspNetCore.Mvc;
using TodoApp.ViewModels;
using TodoApp.ActionFilters;
using TodoApp.Extensions.Validation;
using TodoApp.Extensions;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class AccountController : DataController
    {
        public AccountController(AppService service) : base(service)
        {
        }

        [AvoidRedundantSignFilter]
        public IActionResult Signin() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signin(SigninViewModel? model)
        {
            if (!ModelState.Valid(model, UnitOfWork))
                return View(model);

            this.Signin(model!, UnitOfWork);
            return RedirectToAction("Index", "Home");
        }


        [AvoidRedundantSignFilter]
        public IActionResult Signup() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(SignupViewModel? model)
        {
            if (!ModelState.Valid(model, UnitOfWork))
                return View(model);

            this.SignUp(model!, UnitOfWork);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            this.Signout();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
