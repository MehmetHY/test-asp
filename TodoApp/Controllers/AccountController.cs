using Microsoft.AspNetCore.Mvc;
using TodoModels.ViewModels;
using TodoApp.Utils;
using TodoApp.ActionFilters;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        [AvoidRedundantSignFilter]
        public IActionResult Signin() => View();

        [HttpPost]
        public IActionResult Signin(SigninViewModel? model) =>
            this.RedirectToHomePage();


        [AvoidRedundantSignFilter]
        public IActionResult Signup() => View();

        [HttpPost]
        public IActionResult Signup(SignupViewModel? model) =>
            this.RedirectToSigninPage();
    }
}
