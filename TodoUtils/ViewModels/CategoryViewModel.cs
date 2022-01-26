using TodoModels.Models;

namespace TodoUtils.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryModel Category { get; }
        public CategoryModel? Parent { get; }
        public IEnumerable<CategoryModel> Categories { get; }
        public IEnumerable<TodoModel> Todos { get; }

        public CreateCategoryViewModel CreateCategoryModel { get; set; }

        public CategoryViewModel
            (
                CategoryModel category, 
                CategoryModel? parent, 
                IEnumerable<CategoryModel> categories, 
                IEnumerable<TodoModel> todos,
                CreateCategoryViewModel createCategoryModel
            )
        {
            Category = category;
            Parent = parent;
            Categories = categories;
            Todos = todos;
            CreateCategoryModel = createCategoryModel;
        }
    }
}
