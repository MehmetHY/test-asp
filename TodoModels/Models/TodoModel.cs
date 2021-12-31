using System.ComponentModel.DataAnnotations;

namespace TodoModels.Models
{
    internal class TodoModel
    {
        public int? Id { get; set; }

        public CategoryModel? Category { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [MaxLength(64)]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }

        public enum TodoState { NotStarted, InProgress, Completed } 
        public TodoState State { get; set; } = TodoState.NotStarted;

        public int Index { get; set; }
    }
}
