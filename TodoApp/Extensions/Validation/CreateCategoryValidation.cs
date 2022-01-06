using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApp.ViewModels;
using TodoData.UnitOfWork;

namespace TodoApp.Extensions.Validation
{
    public static class CreateCategoryValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, CreateCategoryViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null)
                return false;

            if (unitOfWork.CategoryRepo.NameExists(model.UserId, model.NewCategoryName))
            {
                model.NewCategoryHasError = true;
                var key = $"CreateCategoryModel.{nameof(model.NewCategoryName)}";
                var error = $"\"{model.NewCategoryName}\" already exists!";
                modelState.AddModelError(key, error);

                return false;
            }

            return true;
        }
    }
}
