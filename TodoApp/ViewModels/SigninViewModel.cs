using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TodoModels.ViewModels
{
    public class SigninViewModel
    {
        [Required(ErrorMessage = "Please enter a user name!")]
        [StringLength(64, ErrorMessage = "Name must be between 4 - 64 characters!", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Remote(action: "ValidateSignin", controller: "Validate", AdditionalFields = nameof(Password))]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        [StringLength(64, ErrorMessage = "Password must be between 4 - 64 characters!", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
