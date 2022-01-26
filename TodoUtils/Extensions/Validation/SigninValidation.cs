using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoData.UnitOfWork;
using TodoUtils.ViewModels;

namespace TodoUtils.Extensions.Validation
{
    public static class SigninValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, SigninViewModel? model, UnitOfWork unitOfWork)
        {
            if (model == null || !modelState.IsValid)
                return false;

            if (!unitOfWork.UserRepo.NameExists(model.Name!))
            {
                modelState.AddModelError(nameof(model.Name), "Invalid Name!");
                return false;
            }

            if (!unitOfWork.UserRepo.PasswordCorrect(model.Name, model.Password))
            {
                modelState.AddModelError(nameof(model.Password), "Invalid password");
                return false;
            }

            return true;
        }
    }
}
