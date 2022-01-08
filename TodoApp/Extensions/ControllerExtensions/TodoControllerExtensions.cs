using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;
using TodoApp.Extensions.Validation;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class TodoControllerExtensions
    {
        public static IActionResult ProceedToCreateTodo(this TodoController controller, TodoViewModel model)
        {
            var userId = controller.GetCurrentAccountId();
            model.UserId = userId;

            if (controller.ModelState.IsCreateTodoValid(model, controller.UnitOfWork))
            {
                var todo = model.Export();
                controller.UnitOfWork.TodoRepo.Add(todo);
                controller.UnitOfWork.SaveChanges();
            }
            else
            {
                controller.TempData["CreateTodoFailed"] = true;
            }

            return model.FromHome ?
                controller.RedirectToAction("Index", "Home") :
                controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });
        }

        public static IActionResult ProceedToUpdateTodo(this TodoController controller, TodoViewModel model)
        {
            var userId = controller.GetCurrentAccountId();
            model.UserId = userId;

            if (controller.ModelState.IsUpdateTodoValid(model, controller.UnitOfWork))
            {
                var todo = model.Export();
                controller.UnitOfWork.TodoRepo.Update(todo);
            }
            else
            {
                controller.TempData["TodoErrorId"] = model.Id;
            }

            return model.FromHome ?
                controller.RedirectToAction("Index", "Home") :
                controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });
        }

        public static IActionResult ProceedToDeleteTodo(this TodoController controller, TodoViewModel model)
        {
            var userId = controller.GetCurrentAccountId();
            model.UserId = userId;

            if (model.IsDeleteTodoValid(controller.UnitOfWork))
            {
                controller.UnitOfWork.TodoRepo.Remove(model.Id);
                controller.UnitOfWork.SaveChanges();
            }

            return model.FromHome ?
                controller.RedirectToAction("Index", "Home") :
                controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });
        }
    }
}
