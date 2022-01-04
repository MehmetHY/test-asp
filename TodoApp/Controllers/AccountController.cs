using Microsoft.AspNetCore.Mvc;
using TodoModels.ViewModels;
using TodoApp.Utils;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Signin() => this.AvoidRedundantSign(View());

        [HttpPost]
        public IActionResult Signin(SigninViewModel? model) =>
            ModelState.IsValid ? this.RedirectToHomePage() : View(model);


        public IActionResult Signup() => this.AvoidRedundantSign(View());

        [HttpPost]
        public IActionResult Signup(SignupViewModel? model) =>
            ModelState.IsValid ? this.RedirectToSigninPage() : View(model);
    }
}
