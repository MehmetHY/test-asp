using Microsoft.AspNetCore.Mvc;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public AppService Service { get; private set; }
        public BaseController(AppService service)
        {
            Service = service;
        }
    }
}
