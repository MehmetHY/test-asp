using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;

namespace TodoApp.ViewModels
{
    public class CreateCategoryViewModel
    {
        [ModelBinder(typeof(TrimModelBinder))]
        [StringLength(64, ErrorMessage = "Category name cannot be longer than 64 characters!")]
        public string? NewCategoryName { get; set; }
        public bool NewCategoryHasError { get; set; } = false;
        public int? UserId { get; set; }
    }
}
