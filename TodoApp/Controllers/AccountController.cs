using Microsoft.AspNetCore.Mvc;
using TodoModels.ViewModels;
using TodoApp.ActionFilters;
using TodoApp.Adapters;
using TodoApp.Extensions;
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
            bool success = true;
            
            if (!ModelState.IsValid)
                success = false;
            
            if (_unitOfWork.UserRepo.NameExists(model!.Name!))
            {
                ModelState.AddModelError(nameof(model.Name), "Name already exists!");
                success = false;
            }

            if (!success)
                return View(model);

            this.SignUp(model!, _unitOfWork);
            return RedirectToAction("Index", "Home");
        }

    }
}
