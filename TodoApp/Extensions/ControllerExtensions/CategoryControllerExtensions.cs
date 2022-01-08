using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;
using TodoApp.Extensions.Validation;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.ControllerExtensions
{
    public static class CategoryControllerExtensions
    {
        public static IActionResult ProceedToCreateCategory(this CategoryController controller, CategoryViewModel model)
        {
            var userId = controller.GetCurrentAccountId();
            model.UserId = userId;

            if (controller.ModelState.IsCreateCategoryValid(model, controller.UnitOfWork))
            {
                var category = model.Export();
                controller.UnitOfWork.CategoryRepo.Add(category);
                controller.UnitOfWork.SaveChanges();
            }
            else
            {
                controller.TempData["CreateCategoryFailed"] = true;
            }

            return model.FromHome ?
                controller.RedirectToAction("Index", "Home") :
                controller.RedirectToAction("Index", "Content", new { categoryId = model.BaseCategoryId });
        }
    }
}
