using System.ComponentModel.DataAnnotations;

namespace TodoModels.Models
{
    internal class CategoryModel
    {
        public int? Id { get; set; }

        public UserModel? User { get; set; }
        
        public CategoryModel? BaseCategory { get; set; }

        public List<CategoryModel> SubCategories { get; set; } = new();

        public List<TodoModel> Todos { get; set; } = new();

        [DataType(DataType.Text)]
        [Required]
        [MaxLength(64)]
        public string? Name { get; set; }
    }
}
