using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;
using TodoApp.Extensions.Validation;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class AccountControllerExtensions
    {
        public static IActionResult ProceedToSignin(this AccountController controller, SigninViewModel? model)
        {
            if (!controller.ModelState.Valid(model, controller.UnitOfWork))
                return controller.View(model);

            controller.Signin(model!, controller.UnitOfWork);

            return controller.RedirectToAction("Index", "Home");
        }
    }
}
