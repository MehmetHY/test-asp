using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;

namespace TodoApp.ViewModels
{
    public class TodoViewModel
    {
        public int? Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Title must be between 4 - 64 characters!", MinimumLength = 4)]
        [ModelBinder(typeof(TrimModelBinder))]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters!")]
        [ModelBinder(typeof(TrimModelBinder))]
        public string Description { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public int? UserId { get; set; }

        public int? State { get; set; }

        public int? Index { get; set; }
        public bool FromHome { get; set; } = true;
    }
}
