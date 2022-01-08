using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApp.ViewModels;
using TodoData.UnitOfWork;

namespace TodoApp.Extensions.Validation
{
    public static class CategoryValidationExtensions
    {
        public static bool IsCreateCategoryValid(this ModelStateDictionary modelState, CategoryViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null || !modelState.IsValid)
                return false;

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                modelState.AddModelError(nameof(model.Name), "Name cannot be empty!");

                return false;
            }

            bool nameExists;

            if (model.BaseCategoryId != null)
            {
                nameExists = unitOfWork.CategoryRepo.NameExistsInCategory(model.BaseCategoryId, model.Name);
            }
            else if (model.UserId != null)
            {
                nameExists = unitOfWork.CategoryRepo.NameExists(model.UserId, model.Name);
            }
            else
            {
                return false;
            }

            if (nameExists)
            {
                modelState.AddModelError(nameof(model.Name), $"\"{model.Name}\" already exists!");

                return false;
            }

            return true;
        }

        public static bool IsUpdateCategoryValid(this ModelStateDictionary modelState, CategoryViewModel? model, UnitOfWork unitOfWork) =>
            modelState.IsCreateCategoryValid(model, unitOfWork);

        public static bool IsDeleteCategoryValid(this CategoryViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null)
                return false;

            if (!unitOfWork.CategoryRepo.UserHasCategory(model.UserId, model.Id))
                return false;

            return true;
        }
    }
}
