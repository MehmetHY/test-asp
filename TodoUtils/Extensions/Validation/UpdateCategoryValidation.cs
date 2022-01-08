using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoUtils.ViewModels;
using TodoData.UnitOfWork;

namespace TodoUtils.Extensions.Validation
{
    public static class UpdateCategoryValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, UpdateCategoryViewModel? model, UnitOfWork unitOfWork)
        {
            if (model?.Category == null || !modelState.IsValid)
                return false;

            if (string.IsNullOrEmpty(model.Category.Name))
            {
                var key = $"{nameof(model.Category)}.{model.Category.Name}";
                var value = "Name cannot be empty!";
                modelState.AddModelError(key, value);

                return false;
            }

            bool nameExists = model.Category.BaseCategoryId == null ?
                unitOfWork.CategoryRepo.NameExists(model.Category.UserId, model.Category.Name)
                    :
                unitOfWork.CategoryRepo.NameExistsInCategory(model.Category.BaseCategoryId, model.Category.Name);

            if (nameExists)
            {
                var key = $"{nameof(model.Category)}.{model.Category.Name}";
                var value = $"\"{model.Category.Name}\" already exists";
                modelState.AddModelError(key, value);

                return false;
            }

            return true;
        }
    }
}
