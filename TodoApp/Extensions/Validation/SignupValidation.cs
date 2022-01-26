using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoData.UnitOfWork;
using TodoApp.ViewModels;

namespace TodoApp.Extensions.Validation
{
    public static class SignupValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, SignupViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null || !modelState.IsValid)
                return false;

            if (unitOfWork.UserRepo.NameExists(model.Name!))
            {
                modelState.AddModelError(nameof(model.Name), "Name already exists!");
                return false;
            }

            return true;
        }
    }
}
