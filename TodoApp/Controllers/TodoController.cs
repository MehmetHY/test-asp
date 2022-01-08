using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class TodoController : DataController
    {
        public TodoController(AppService service) : base(service)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Create([FromForm] TodoViewModel model) =>
            this.ProceedToCreateTodo(model);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Update(TodoViewModel model) =>
            this.ProceedToUpdateTodo(model);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Delete(TodoViewModel model) =>
            this.ProceedToDeleteTodo(model);

    }
}
