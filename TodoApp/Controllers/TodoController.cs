using Microsoft.AspNetCore.Mvc;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class TodoController : BaseController
    {
        public TodoController(AppService service) : base(service)
        {
        }
    }
}
