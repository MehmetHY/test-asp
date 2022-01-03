using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Signin()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
    }
}
