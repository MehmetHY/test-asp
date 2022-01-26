using TodoData.UnitOfWork;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class ContentViewModel
    {
        public CategoryModel? Category { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public IEnumerable<TodoModel> Todos { get; set; } = new List<TodoModel>();

        public CategoryViewModel CategoryViewModel { get; set; } = new();
        public TodoViewModel TodoViewModel { get; set; } = new();

        public static class Factory
        {
            public static ContentViewModel Create(UnitOfWork unitOfWork, int? categoryId)
            {
                var category = unitOfWork.CategoryRepo.Get(categoryId);
                var categories = unitOfWork.CategoryRepo.GetOfCategory(categoryId);
                var todos = unitOfWork.TodoRepo.GetOfCategory(categoryId);

                var categoryViewModel = new CategoryViewModel
                {
                    BaseCategoryId = categoryId,
                    FromHome = false
                };

                var model = new ContentViewModel()
                {
                    Category = category,
                    Categories = categories,
                    Todos = todos,
                    CategoryViewModel = categoryViewModel
                };

                return model;
            }
        }
    }
}
