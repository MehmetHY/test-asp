using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoUtils.ModelBinders;

namespace TodoUtils.ViewModels
{
    public class CreateCategoryViewModel
    {
        [ModelBinder(typeof(TrimModelBinder))]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Category name cannot be longer than 64 characters!")]
        public string? NewCategoryName { get; set; }
        public bool NewCategoryHasError { get; set; } = false;
        public int? UserId { get; set; }
        public int? BaseCategoryId { get; set; }
        public bool FromHome { get; set; } = true;
    }
}
