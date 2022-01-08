using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;
using TodoModels.Models;

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

        public int State { get; set; } = 1;

        public int? Index { get; set; }

        public bool FromHome { get; set; } = true;

        public void Import(TodoModel model)
        {
            Title = model.Title;
            Description = model.Description ?? string.Empty;
            CategoryId = model.CategoryId;
            UserId = model.UserId;
            State = model.State == null || model.State.Value == 0 ? 1 : model.State.Value;
            Index = model.Index;
        }

        public TodoModel Export()
        {
            var model = new TodoModel
            {
                Title = Title,
                Description = Description,
                CategoryId = CategoryId,
                UserId = UserId,
                State = State,
                Index = Index
            };

            return model;
        }
    }
}
