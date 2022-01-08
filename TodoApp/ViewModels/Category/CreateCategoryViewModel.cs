using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;

namespace TodoApp.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Name must be between 4 - 64 characters!")]
        [ModelBinder(typeof(TrimModelBinder))]
        public string? Name { get; set; }
        
        public int? BaseId { get; set; }
        
        public int? UserId { get; set; }
        
        public bool FromHome { get; set; } = true;
    }
}
