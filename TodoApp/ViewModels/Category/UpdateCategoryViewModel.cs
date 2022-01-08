using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;
using TodoModels.Models;

namespace TodoApp.ViewModels.Category
{
    public class UpdateCategoryViewModel
    {
        public int? Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Name must be between 4 - 64 characters!")]
        [ModelBinder(typeof(TrimModelBinder))]
        public string? Name { get; set; }
        
        public int? BaseId { get; set; }
        
        public int? UserId { get; set; }
        
        public bool FromHome { get; set; } = true;


        public void Import(CategoryModel model)
        {
            Id = model.Id;
            Name = model.Name;
            BaseId = model.BaseCategoryId;
            UserId = model.UserId;
        }
    }
}
