using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Extensions
{
    public static class RedirectExtensions
    {
        private const string SIGN_IN = "Signin";
        private const string ACCOUNT = "Account";
        private const string INDEX = "Index";
        private const string HOME = "Home";

        public static IActionResult RedirectToHomePage(this Controller controller) =>
            controller.RedirectToAction(INDEX, HOME);

         public static IActionResult RedirectToSigninPage(this Controller controller) =>
            controller.RedirectToAction(SIGN_IN, ACCOUNT);

        public static IActionResult GetAuthActionResult(this Controller controller, IActionResult target)
            => controller.IsSignedIn() ? target : controller.RedirectToSigninPage();

        public static IActionResult AvoidRedundantSign(this Controller controller, IActionResult target)
            => controller.IsSignedIn() ? target : controller.RedirectToHomePage();
    }
}
