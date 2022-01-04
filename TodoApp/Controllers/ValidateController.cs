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
        public IActionResult ValidateSignin(string? name, string? password)
        {
            string? error = null;

            if (string.IsNullOrWhiteSpace(name))
                error = "Name cannot be empty!";
            else if (string.IsNullOrWhiteSpace(password))
                error = "Password cannot be empty!";
            else if (!_unitOfWork.UserRepo.NameExists(name))
                error = "Invalid user name!";
            else if (!_unitOfWork.UserRepo.PasswordCorrect(name, password))
                error = "Invalid password!";
            
            return error == null ? Json(true) : Json(error);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateSignup(string? name)
        {
            string? error = null;

            if (string.IsNullOrWhiteSpace(name)) error = "Name cannot be empty!";
            else if (_unitOfWork.UserRepo.NameExists(name)) error = "Username already exists!";
            
            return error == null ? Json(true) : Json(error);
        }
    }
}
