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
            var model = new HomeViewModel { Categories = categories };
            return model;
        }
    }
}
