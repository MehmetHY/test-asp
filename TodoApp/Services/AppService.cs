using TodoApp.ViewModels.Factories;
using TodoData.UnitOfWork;

namespace TodoApp.Services
{
    public class AppService
    {
        public HomeViewModelFactory HomeViewModelFactory{ get; set; }
        public ContentViewModelFactory CategoryViewModelFactory{ get; set; }
        public UnitOfWork UnitOfWork { get; set; }
        public AppService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            HomeViewModelFactory = new(UnitOfWork);
            CategoryViewModelFactory = new(UnitOfWork);
        }
    }
}
