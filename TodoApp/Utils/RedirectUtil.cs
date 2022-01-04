using Microsoft.AspNetCore.Mvc;

namespace TodoUtils.Utils
{
    public static class RedirectUtil
    {
        private const string SIGN_IN = "Signin";
        private const string ACCOUNT = "Account";
        private const string INDEX = "Index";
        private const string HOME = "Home";

        public static IActionResult GetAuthActionResult(this Controller controller, IActionResult target)
            => controller.IsSignedIn() ? target : controller.RedirectToAction(SIGN_IN, ACCOUNT);

        public static IActionResult AvoidRedundantSign(this Controller controller, IActionResult target)
            => controller.IsSignedIn() ? target : controller.RedirectToAction(INDEX, HOME);
    }
}
