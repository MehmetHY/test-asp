using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApp.ViewModels;
using TodoData.UnitOfWork;

namespace TodoApp.Extensions.Validation
{
    public static class CreateCategoryValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, CategoryViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null)
                return false;

            int? userId = model.Categories.FirstOrDefault()?.UserId ?? null;

            if (unitOfWork.CategoryRepo.NameExists(userId, model.NewCategoryName))
            {
                model.NewCategoryHasError = true;
                modelState.AddModelError(nameof(model.NewCategoryName), $"\"{model.NewCategoryName}\" already exists!");

                return false;
            }

            return true;
        }
    }
}
