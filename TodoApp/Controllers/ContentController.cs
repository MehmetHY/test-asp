using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
    }
}
