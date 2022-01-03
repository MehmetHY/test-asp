using Microsoft.AspNetCore.Mvc;
using TodoModels.ViewModels;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Signin() => View();

        [HttpPost]
        public IActionResult Signin(SigninViewModel? model) => 
            ModelState.IsValid ? RedirectToAction("Index", "Home") : View(model);


        public IActionResult Signup() => View();

        [HttpPost]
        public IActionResult Signup(SignupViewModel? model) =>
            ModelState.IsValid ? RedirectToAction(nameof(Signin)) : View(model);
    }
}
