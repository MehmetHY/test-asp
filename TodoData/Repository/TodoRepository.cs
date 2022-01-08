using DbAccess.Data;
using DbAccess.Data.Models;
using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class TodoRepository : Repository<TodoModel>, ITodoRepository
    {
        public TodoRepository(IProcedureCaller pc) : base(pc) {}

        public TodoModel? GetByIndex(int? index, int? categoryId, int? userId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(index), index },
                { nameof(categoryId), categoryId },
                { nameof(userId), userId }
            };
            var sp = new StoredProcedureModel(typeof(TodoModel), nameof(GetByIndex), parameters);
            var result = _spCaller.GetRow<TodoModel>(sp);
            return result;
        }

        public TodoModel? GetUpperNeighbour(int? index, int? categoryId, int? userId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(index), index },
                { nameof(categoryId), categoryId },
                { nameof(userId), userId }
            };
            var sp = new StoredProcedureModel(typeof(TodoModel), nameof(GetUpperNeighbour), parameters);
            var result = _spCaller.GetRow<TodoModel>(sp);
            return result;
        }

        public TodoModel? GetLowerNeighbour(int? index, int? categoryId, int? userId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(index), index },
                { nameof(categoryId), categoryId },
                { nameof(userId), userId }
            };
            var sp = new StoredProcedureModel(typeof(TodoModel), nameof(GetLowerNeighbour), parameters);
            var result = _spCaller.GetRow<TodoModel>(sp);
            return result;
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

        public void Update(TodoModel? model)
        {
            if (model == null)
                return;

            var parameters = new Dictionary<string, object?>
            {
                { nameof(model.Id), model.Id },
                { nameof(model.Title), model.Title },
                { nameof(model.Description), model.Description },
                { nameof(model.State), model.State },
                { nameof(model.Index), model.Index }
            };
            
            var sp = new StoredProcedureModel(typeof(TodoModel), nameof(Update), parameters);

            _spCaller.Execute(sp);
        }
    }
}
