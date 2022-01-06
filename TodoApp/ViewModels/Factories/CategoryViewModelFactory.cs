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

        public CategoryViewModel? CreateCategoryViewModel(int? userId, int? categoryId)
        {
            if (categoryId == null || userId == null)
                return null;

            var category = _unitOfWork.CategoryRepo.Get(categoryId);

            if (category == null) 
                return null;

            var parent = _unitOfWork.CategoryRepo.Get(category.BaseCategoryId);

            if (parent == null)
                return null;

            var categories = _unitOfWork.CategoryRepo.GetOfCategory(categoryId);
            var todos = _unitOfWork.TodoRepo.GetOfCategory(categoryId);

            var model = new CategoryViewModel
            {
                Category = category,
                Parent = parent,
                Categories = categories,
                Todos = todos
            };

            return model;
        }
    }
}
