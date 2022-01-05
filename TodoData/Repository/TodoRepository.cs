using DbAccess.Data;
using DbAccess.Data.Models;
using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class TodoRepository : Repository<TodoModel>, ITodoRepository
    {
        public TodoRepository(IProcedureCaller pc) : base(pc)
        {
        }

        public IEnumerable<TodoModel> GetOfCategory(int? categoryId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(categoryId), categoryId }
            };
            var sp = new StoredProcedureModel(typeof(TodoModel), nameof(GetOfCategory), parameters);
            var result = _spCaller.GetRows<TodoModel>(sp);
            return result;
        }

        public IEnumerable<TodoModel> GetOfCategoryByName(int? userId, string? categoryName)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(userId), userId },
                { nameof(categoryName), categoryName }
            };
            var sp = new StoredProcedureModel(typeof(TodoModel), nameof(GetOfCategoryByName), parameters);
            var result = _spCaller.GetRows<TodoModel>(sp);
            return result;
        }

        public IEnumerable<TodoModel> GetOfUser(int? userId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(userId), userId }
            };
            var sp = new StoredProcedureModel(typeof(TodoModel), nameof(GetOfUser), parameters);
            var result = _spCaller.GetRows<TodoModel>(sp);
            return result;
        }
    }
}
