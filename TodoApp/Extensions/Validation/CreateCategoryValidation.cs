using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApp.ViewModels;
using TodoData.UnitOfWork;

namespace TodoApp.Extensions.Validation
{
    public static class CreateCategoryValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, CreateCategoryViewModel? model, UnitOfWork unitOfWork, out Dictionary<string, string> errors)
        {
            errors = new Dictionary<string, string>();
            if (model == null || !modelState.IsValid)
                return false;

            if (string.IsNullOrWhiteSpace(model.NewCategoryName))
            {
                model.NewCategoryHasError = true;
                var key = $"CreateCategoryModel.{nameof(model.NewCategoryName)}";
                var error = "Name cannot be empty!";
                errors.Add(key, error);

                return false;
            }

            if (unitOfWork.CategoryRepo.NameExists(model.UserId, model.NewCategoryName))
            {
                model.NewCategoryHasError = true;
                var key = $"CreateCategoryModel.{nameof(model.NewCategoryName)}";
                var error = $"\"{model.NewCategoryName}\" already exists!";
                errors.Add(key, error);

                return false;
            }

            return true;
        }
    }
}
