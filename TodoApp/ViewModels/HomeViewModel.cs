using TodoData.UnitOfWork;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryModel> Categories { get; private set; } = new List<CategoryModel>();

        public CategoryViewModel CategoryViewModel { get; set; } = new();

        public static class Factory
        {
            public static HomeViewModel Create(UnitOfWork unitOfWork, int? userId)
            {
                var categories = unitOfWork.CategoryRepo.GetOfUser(userId);
                var categoryView = CategoryModel.Factory.Create(true);

                var model = new HomeViewModel
                {
                    Categories = categories
                };

                return model;
            }
        }
    }
}
