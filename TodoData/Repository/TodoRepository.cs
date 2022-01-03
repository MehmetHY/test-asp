using DbAccess.Data.Interfaces;
using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class TodoRepository : Repository<TodoModel>
    {
        public TodoRepository(IProcedureCaller pc) : base(pc) {}
        
    }
}
