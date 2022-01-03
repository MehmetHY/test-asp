﻿using Microsoft.AspNetCore.Mvc;

namespace TodoUtils.Utils
{
    public class RedirectUtil
    {
        private readonly IActionResult _signInAction;
        private readonly IActionResult _homeAction;
        private readonly AccountUtil _accountUtil;
        public RedirectUtil(Controller controller)
        {
            _signInAction = controller.RedirectToAction("Signin", "Account");
            _homeAction = controller.RedirectToAction("Index", "Home");
            _accountUtil = new AccountUtil(controller.HttpContext.Session);
        }
        public IActionResult GetAuthActionResult(IActionResult target)
            => _accountUtil.SignedIn ? target : _signInAction;

        public IActionResult AvoidRedundantSign(IActionResult target)
            => _accountUtil.SignedIn ? _homeAction : target;
    }
}