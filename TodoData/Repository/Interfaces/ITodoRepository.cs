using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public interface ITodoRepository
    {
        IEnumerable<TodoModel> GetOfUser(int userId);
        IEnumerable<TodoModel> GetOfCategory(int categoryId);
    }
}
