using Microsoft.AspNetCore.Mvc;
using TodoModels.ViewModels;
using TodoUtils.Utils;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Signin() => new RedirectUtil(this).AvoidRedundantSign(View());

        [HttpPost]
        public IActionResult Signin(SigninViewModel? model)
        {

            return ModelState.IsValid ? RedirectToAction("Index", "Home") : View(model);
        }


        public IActionResult Signup() => new RedirectUtil(this).AvoidRedundantSign(View());

        [HttpPost]
        public IActionResult Signup(SignupViewModel? model) =>
            ModelState.IsValid ? RedirectToAction(nameof(Signin)) : View(model);
    }
}
