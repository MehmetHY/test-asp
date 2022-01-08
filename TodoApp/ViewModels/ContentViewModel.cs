using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class ContentViewModel
    {
        public CategoryModel? Category { get; set; }
        public List<CategoryModel> Categories { get; set; } = new();
        public List<TodoModel> Todos { get; set; } = new();

        public CreateCategoryViewModel CreateCategoryViewModel { get; set; } = new();
        public UpdateCategoryViewModel UpdateCategoryViewModel { get; set; } = new();
        public DeleteCategoryViewModel DeleteCategoryViewModel { get; set; } = new();
        
        public CreateTodoViewModel CreateTodoViewModel { get; set; } = new();
        public UpdateTodoViewModel UpdateTodoViewModel { get; set; } = new();
        public DeleteTodoViewModel DeleteTodoViewModel { get; set; } = new();
    }
}
