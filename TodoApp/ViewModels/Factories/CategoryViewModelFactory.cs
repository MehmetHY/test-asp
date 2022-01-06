using TodoData.UnitOfWork;

namespace TodoApp.ViewModels.Factories
{
    public class CategoryViewModelFactory
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryViewModelFactory(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CategoryViewModel? Create(int? userId, int? rootCategoryId)
        {
            if (rootCategoryId == null || userId == null)
                return null;

            CategoryViewModel? categoryViewModel = new();
            return categoryViewModel;
        }
    }
}
