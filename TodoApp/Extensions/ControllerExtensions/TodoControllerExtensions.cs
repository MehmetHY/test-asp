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

            return controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });
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

            return controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });
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

            return controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });
        }

        public static IActionResult ProceedToChangeTodoState(this TodoController controller, TodoViewModel model)
        {
            model.State = ++model.State > 3 ? 1 : model.State;
            return controller.ProceedToUpdateTodo(model);
        }
        public static IActionResult ProceedToMoveTodo(this TodoController controller, TodoViewModel model, bool moveUp)
        {
            var userId = controller.GetCurrentAccountId();

            var targetModel = moveUp ?
                controller.UnitOfWork.TodoRepo.GetUpperNeighbour(model.Index, model.CategoryId, userId) :
                controller.UnitOfWork.TodoRepo.GetLowerNeighbour(model.Index, model.CategoryId, userId);

            if (targetModel == null)
                return controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });

            var tempIndex = targetModel.Index;
            targetModel.Index = model.Index;
            model.Index = tempIndex;

            controller.UnitOfWork.TodoRepo.Update(targetModel);
            controller.UnitOfWork.TodoRepo.Update(model.Export());

            return controller.RedirectToAction("Index", "Content", new { categoryId = model.CategoryId });
        }
    }
}
