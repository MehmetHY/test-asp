using TodoApp.Services;
using TodoData.UnitOfWork;

namespace TodoApp.Controllers.Abstract
{
    public class DataController : BaseController
    {
        public UnitOfWork UnitOfWork { get; private set; }
        public DataController(AppService service) : base(service)
        {
            UnitOfWork = service.UnitOfWork;
        }
    }
}
