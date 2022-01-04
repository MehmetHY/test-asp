using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoData.UnitOfWork;
using TodoModels.ViewModels;

namespace TodoApp.Extensions.Validation
{
    public static class SignupValidation
    {
        public static bool Valid(this ModelStateDictionary modelState, SignupViewModel model, UnitOfWork unitOfWork)
        {
            bool valid = true;

            if (!modelState.IsValid)
                valid = false;

            if (unitOfWork.UserRepo.NameExists(model.Name!))
                valid = false;

            return valid;
        }
    }
}
