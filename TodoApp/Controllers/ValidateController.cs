using Microsoft.AspNetCore.Mvc;
using TodoApp.Utils;
using TodoData.UnitOfWork;

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
        public IActionResult ValidateSigninName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Json("Name cannot be empty!");

            if (!_unitOfWork.UserRepo.NameExists(name))
                return Json("Invalid user name!");

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateSigninPassword(string? name, string? password)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                return Json("Enter user name first!");

            if (string.IsNullOrWhiteSpace(password))
                return Json("Password cannot be empty!");

            password = password.ToHashSha256();
            if (!_unitOfWork.UserRepo.PasswordCorrect(name, password))
                return Json("Invalid password!");

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateSignupName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                return Json("Name cannot be empty!");

            if (_unitOfWork.UserRepo.NameExists(name)) 
                return Json("Username already exists!");
            
            return Json(true);
        }
    }
}
