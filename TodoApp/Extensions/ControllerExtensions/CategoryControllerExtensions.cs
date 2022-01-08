using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class CategoryControllerExtensions
    {
        public static IActionResult ProceedToCreateCategory(this CategoryController controller, CategoryViewModel? model)
        {
            if (controller.ModelState.IsCreateCategoryValid(model, controller.UnitOfWork))
            {
                var category = model!.Export();
                controller.UnitOfWork.CategoryRepo.Add(category);
                controller.UnitOfWork.SaveChanges();
            }

            return model?.FromHome ?? true ?
                controller.RedirectToAction("Index", "Home") :
                controller.RedirectToAction("Index", "Content", new { categoryId = model.Id });
        }
    }
}
