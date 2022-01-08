using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Name must be between 4 - 64 characters!")]
        [ModelBinder(typeof(TrimModelBinder))]
        public string? Name { get; set; }
        public int? UserId { get; set; }
        public int? BaseCategoryId { get; set; }
        public bool FromHome { get; set; } = true;

        public void Import(CategoryModel? model, bool fromHome = true)
        {
            if (model == null)
                return;

            Id = model.Id;
            Name = model.Name;
            UserId = model.UserId;
            BaseCategoryId = model.BaseCategoryId;
            FromHome = fromHome;
        }
    }
}
