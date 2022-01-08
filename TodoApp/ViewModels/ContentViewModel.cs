using TodoApp.Controllers;
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
            public static ContentViewModel Create(UnitOfWork unitOfWork, int? id)
            {
                var category = unitOfWork.CategoryRepo.Get(id);
                var categories = unitOfWork.CategoryRepo.GetOfCategory(id);
                var todos = unitOfWork.TodoRepo.GetOfCategory(id);

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
