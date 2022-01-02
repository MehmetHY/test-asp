using TodoData.Data.Interfaces;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class TodoRepository : Repository<TodoModel>
    {
        public TodoRepository(IProcedureCaller pc) : base(pc) {}
        
    }
}
