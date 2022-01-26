using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoUtils.ViewModels;
using TodoData.UnitOfWork;

namespace TodoUtils.Extensions.Validation
{
    public static class CreateCategoryValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, CreateCategoryViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null || !modelState.IsValid)
                return false;

            if (string.IsNullOrWhiteSpace(model.NewCategoryName))
            {
                model.NewCategoryHasError = true;
                var key = nameof(model.NewCategoryName);
                var error = "Name cannot be empty!";
                modelState.AddModelError(key, error);

                return false;
            }

            bool nameExists = model.FromHome ?
                unitOfWork.CategoryRepo.NameExists(model.UserId, model.NewCategoryName) :
                unitOfWork.CategoryRepo.NameExistsInCategory(model.BaseCategoryId, model.NewCategoryName);

            if (nameExists)
            {
                model.NewCategoryHasError = true;
                var key = nameof(model.NewCategoryName);
                var error = $"\"{model.NewCategoryName}\" already exists!";
                modelState.AddModelError(key, error);

                return false;
            }

            return true;
        }
    }
}
