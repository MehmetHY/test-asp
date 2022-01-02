using TodoData.Data.Interfaces;
using TodoData.Repository.Interface;
using TodoModels.Models;
using Dapper;

namespace TodoData.Repository
{
    public class TodoRepository : IRepository<TodoModel>
    {
        private readonly IProcedureCaller _pc;
        public TodoRepository(IProcedureCaller pc)
        {
            _pc = pc;
        }
        
        public void Add(TodoModel entity)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Title", entity.Title, System.Data.DbType.String, System.Data.ParameterDirection.Input, 64);
            param.Add("Description", entity.Description, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            param.Add("State", (int)entity.State, System.Data.DbType.Int16, System.Data.ParameterDirection.Input);
            param.Add("Index", entity.Index, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            _pc.Execute("sp_todo_add", param);
        }

        public void AddRange(IEnumerable<TodoModel> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public TodoModel? Get(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var entity = _pc.GetRow<TodoModel>("sp_todo_get_by_id", param);
            return entity;
        }

        public IEnumerable<TodoModel> GetAll()
        {
            var todos = _pc.GetRows<TodoModel>("sp_todo_get_all");
            return todos;
        }

        public void Remove(int id)
        {
            var param = new DynamicParameters();
            param.Add("Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            _pc.Execute("sp_todo_remove_by_id", param);
        }

        public void Remove(TodoModel entity)
        {
            Remove(entity.Id ?? -1);
        }

        public void RemoveAll()
        {
            _pc.Execute("sp_todo_remove_all");
        }

        public void RemoveRange(IEnumerable<TodoModel> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }
    }
}
