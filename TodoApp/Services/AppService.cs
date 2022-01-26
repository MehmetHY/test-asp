using TodoData.UnitOfWork;

namespace TodoApp.Services
{
    public class AppService
    {
        public UnitOfWork UnitOfWork { get; set; }
        public AppService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
