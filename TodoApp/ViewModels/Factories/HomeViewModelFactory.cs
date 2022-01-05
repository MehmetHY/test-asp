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

        public HomeViewModel? CreateHomeViewModel(Controller controller, string? categoryName = null)
        {
            var viewModel = new HomeViewModel();
            int userId = controller.GetCurrentAccountId()!.Value;
            
            if (categoryName == string.Empty)
            {
                viewModel.Categories = _unitOfWork.CategoryRepo.GetOfUser(userId).ToList();
                viewModel.Todos = _unitOfWork.TodoRepo.GetOfUser(userId).ToList();
                return viewModel;
            }

            var category = _unitOfWork.CategoryRepo.GetByName(userId, categoryName);
            
            if (category != null)
            {
                viewModel.Category = category;
                viewModel.Categories = _unitOfWork.CategoryRepo.GetOfCategory(category.Id).ToList();
                viewModel.Todos = _unitOfWork.TodoRepo.GetOfCategory(category.Id).ToList();
            }
            else
            {
                viewModel = null;
            }

            return viewModel;
        }
    }
}
