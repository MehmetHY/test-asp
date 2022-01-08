using TodoUtils.ViewModels.Factories;
using TodoData.UnitOfWork;

namespace TodoUtils.Services
{
    public class AppService
    {
        public HomeViewModelFactory HomeViewModelFactory{ get; set; }
        public CategoryViewModelFactory CategoryViewModelFactory{ get; set; }
        public UnitOfWork UnitOfWork { get; set; }
        public AppService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            HomeViewModelFactory = new(UnitOfWork);
            CategoryViewModelFactory = new(UnitOfWork);
        }
    }
}
