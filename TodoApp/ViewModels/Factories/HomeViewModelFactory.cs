using TodoData.UnitOfWork;

namespace TodoApp.ViewModels.Factories
{
    public class HomeViewModelFactory
    {
        private readonly UnitOfWork _unitOfWork;
        public HomeViewModelFactory(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public HomeViewModel? CreateHomeViewModel(int? userId)
        {
            if (userId == null)
                return null;

            var categories = _unitOfWork.CategoryRepo.GetOfUser(userId);

            var createCategoryModel = new CreateCategoryViewModel 
            { 
                UserId = userId,
                FromHome = true
            };

            var model = new HomeViewModel(categories, createCategoryModel);
            
            return model;
        }
    }
}
