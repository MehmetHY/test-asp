using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApp.ViewModels;
using TodoData.UnitOfWork;

namespace TodoApp.Extensions.Validation
{
    public static class TodoValidationExtensions
    {
        public static bool IsCreateTodoValid(this ModelStateDictionary modelState, TodoViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null || !modelState.IsValid)
                return false;

            if (!unitOfWork.CategoryRepo.UserHasCategory(model.UserId, model.CategoryId))
                return false;

            if (string.IsNullOrWhiteSpace(model.Title))
            {
                modelState.AddModelError(nameof(model.Title), "Name cannot be empty!");

                return false;
            }

            if (model.Title.Length > 64)
            {
                modelState.AddModelError(nameof(model.Title), "Name cannot be longer than 64 characters!");

                return false;
            }
            if (model.Description.Length > 1000)
            {
                modelState.AddModelError(nameof(model.Description), "Description cannot be longer than 1000 characters!");

                return false;
            }

            return true;
        }

        public static bool IsUpdateTodoValid(this ModelStateDictionary modelState, TodoViewModel? model, UnitOfWork unitOfWork) =>
            modelState.IsCreateTodoValid(model, unitOfWork);

        public static bool IsDeleteTodoValid(this TodoViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null)
                return false;

            if (!unitOfWork.CategoryRepo.UserHasCategory(model.UserId, model.CategoryId))
                return false;

            return true;
        }
    }
}
