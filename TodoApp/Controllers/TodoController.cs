using Microsoft.AspNetCore.Mvc;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class TodoController : DataController
    {
        public TodoController(AppService service) : base(service)
        {
        }
    }
}
