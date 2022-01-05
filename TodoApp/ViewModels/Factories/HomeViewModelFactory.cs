using Microsoft.AspNetCore.Mvc;
using TodoData.UnitOfWork;
using TodoApp.Extensions;

namespace TodoApp.ViewModels.Factories
{
    public class HomeViewModelFactory
    {
        private readonly UnitOfWork _unitOfWork;
        public HomeViewModelFactory(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public HomeViewModel CreateHomeViewModel(Controller controller)
        {
            var viewModel = new HomeViewModel();
            int userId = controller.GetCurrentAccountId()!.Value;
            viewModel.Load(userId, _unitOfWork);
            return viewModel;
        }
    }
}
