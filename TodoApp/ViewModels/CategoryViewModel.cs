using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryModel Category { get; set; }
        public CategoryModel Parent { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<TodoModel> Todos { get; set; }

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
