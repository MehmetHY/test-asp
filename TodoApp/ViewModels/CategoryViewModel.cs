using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryModel Category { get; }
        public CategoryModel Parent { get; }
        public IEnumerable<CategoryModel> Categories { get; }
        public IEnumerable<TodoModel> Todos { get; }

        public CategoryViewModel
            (
                CategoryModel category, 
                CategoryModel parent, 
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
