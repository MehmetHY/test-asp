using TodoApp.Controllers;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class ContentViewModel
    {
        public CategoryModel? Category { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public IEnumerable<TodoModel> Todos { get; set; } = new List<TodoModel>();
        
        public CreateTodoViewModel CreateTodoViewModel { get; set; } = new();
        public UpdateTodoViewModel UpdateTodoViewModel { get; set; } = new();
        public DeleteTodoViewModel DeleteTodoViewModel { get; set; } = new();

        public static class Factory
        {
            public static ContentViewModel Create(ContentController controller, int? id)
            {
                var category = controller.UnitOfWork.CategoryRepo.Get(id);
                var categories = controller.UnitOfWork.CategoryRepo.GetOfCategory(id);
                var todos = controller.UnitOfWork.TodoRepo.GetOfCategory(id);

                var model = new ContentViewModel()
                {
                    Category = category,
                    Categories = categories,
                    Todos = todos
                };

                return model;
            }
        }
    }
}
