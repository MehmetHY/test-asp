using System.ComponentModel.DataAnnotations;

namespace TodoModels.Models
{
    public class TodoModel
    {
        [Key]
        public int? Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [MaxLength(64)]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }

        public enum TodoState { NotStarted, InProgress, Completed } 

        [Required]
        [EnumDataType(typeof(TodoState))]
        public TodoState State { get; set; } = TodoState.NotStarted;

        public int Index { get; set; }
    }
}
