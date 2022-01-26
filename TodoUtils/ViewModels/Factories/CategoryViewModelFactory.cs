using TodoData.UnitOfWork;

namespace TodoUtils.ViewModels.Factories
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

            if (!_unitOfWork.CategoryRepo.UserHasCategory(userId, categoryId))
                return null;

            var category = _unitOfWork.CategoryRepo.Get(categoryId);

            if (category == null) 
                return null;

            var parent = _unitOfWork.CategoryRepo.Get(category.BaseCategoryId);

            var categories = _unitOfWork.CategoryRepo.GetOfCategory(categoryId);
            var todos = _unitOfWork.TodoRepo.GetOfCategory(categoryId);

            var createCategoryModel = new CreateCategoryViewModel
            {
                UserId = userId,
                BaseCategoryId = categoryId,
                FromHome = false
            };
            
            var model = new CategoryViewModel
                (
                    category, 
                    parent,
                    categories, 
                    todos, 
                    createCategoryModel
                );

            return model;
        }
    }
}
