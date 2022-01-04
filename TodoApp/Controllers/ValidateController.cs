using Microsoft.AspNetCore.Mvc;
using TodoData.UnitOfWork;
using TodoModels.Models;

namespace TodoApp.Controllers
{
    public class ValidateController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public ValidateController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateSignin(UserModel? model)
        {
            string? error = null;

            if (model == null) error = "Invalid user";
            else if (model.Name == null) error = "Name cannot be empty!";
            else if (model.Password == null) error = "Password cannot be empty!";
            else if (!_unitOfWork.UserRepo.NameExists(model.Name)) error = "Invalid user name!";
            else if (!_unitOfWork.UserRepo.PasswordCorrect(model)) error = "Invalid password!";
            
            return error == null ? Json(true) : Json(error);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateSignup(UserModel? model)
        {
            string? error = null;

            if (model == null) error = "Invalid user";
            else if (model.Name == null) error = "Name cannot be empty!";
            else if (model.Password == null) error = "Password cannot be empty!";
            else if (_unitOfWork.UserRepo.NameExists(model.Name)) error = "Username already exists!";
            
            return error == null ? Json(true) : Json(error);
        }
    }
}
