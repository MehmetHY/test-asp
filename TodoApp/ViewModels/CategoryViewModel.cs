using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryModel Category { get; }
        public CategoryModel? Parent { get; }
        public IEnumerable<CategoryModel> Categories { get; }
        public IEnumerable<TodoModel> Todos { get; }

        [ModelBinder(typeof(TrimModelBinder))]
        [StringLength(64, ErrorMessage = "Category name cannot be longer than 64 characters!")]
        public string? NewCategoryName { get; set; }
        public bool NewCategoryHasError { get; set; } = false;

        public CategoryViewModel
            (
                CategoryModel category, 
                CategoryModel? parent, 
                IEnumerable<CategoryModel> categories, 
                IEnumerable<TodoModel> todos
            )
        {
            Category = category;
            Parent = parent;
            Categories = categories;
            Todos = todos;
        }
    }
}
