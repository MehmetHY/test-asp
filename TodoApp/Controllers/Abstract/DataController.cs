using TodoApp.Services;
using TodoData.UnitOfWork;

namespace TodoApp.Controllers
{
    public abstract class DataController : BaseController
    {
        public UnitOfWork UnitOfWork { get; private set; }
        public DataController(AppService service) : base(service)
        {
            UnitOfWork = service.UnitOfWork;
        }
    }
}
