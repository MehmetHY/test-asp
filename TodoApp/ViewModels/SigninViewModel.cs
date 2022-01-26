using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;

namespace TodoApp.ViewModels
{
    public class SigninViewModel
    {
        [Required(ErrorMessage = "Please enter a user name!")]
        [StringLength(64, ErrorMessage = "Name must be between 4 - 64 characters!", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [ModelBinder(typeof(TrimModelBinder))]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        [StringLength(64, ErrorMessage = "Password must be between 4 - 64 characters!", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [ModelBinder(typeof(HashModelBinder))]
        public string? Password { get; set; }
    }
}
