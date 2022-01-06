﻿using Microsoft.AspNetCore.Mvc;
using TodoApp.ViewModels;
using TodoApp.ActionFilters;
using TodoApp.Extensions.Validation;
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
