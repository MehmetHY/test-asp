using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryModel? Category { get; set; } = null;
        public CategoryModel? Parent { get; set; } = null;
        public List<CategoryModel> Categories { get; set; } = new();
        public List<TodoModel> Todos { get; set; } = new();
    }
}
