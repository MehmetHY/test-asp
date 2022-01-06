using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryModel? Category { get; set; } = null;
        public CategoryModel? Parent { get; set; } = null;
        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public IEnumerable<TodoModel> Todos { get; set; } = new List<TodoModel>();
    }
}
