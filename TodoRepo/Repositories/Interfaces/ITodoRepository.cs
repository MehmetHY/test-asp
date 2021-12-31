using TodoModels.Models;
using DbAccess.Repo.Interfaces;

namespace TodoModels.Repositories
{
    public interface ITodoRepository  : IRepository<TodoModel>
    {
        Task Update(TodoModel todo);
        Task<bool> Any(TodoModel todo);
        Task<bool> Any(int id);
        Task<IEnumerable<TodoModel>> GetTodosOfCategory(int id);
    }
}
