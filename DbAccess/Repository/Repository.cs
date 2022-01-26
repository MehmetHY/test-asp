using DbAccess.Data;
using DbAccess.Attributes;
using DbAccess.Utils;
using DbAccess.Data.Models;

namespace DbAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IProcedureCaller _spCaller;
        protected Queue<StoredProcedureModel> _spQueue = new();

        public Repository(IProcedureCaller pc)
        {
            _spCaller = pc;
        }

        public void Add(T? entity)
        {
            if (entity == null) return;
            var parameters = new Dictionary<string, object?>();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.HasAttribute<PrimaryKey>()) continue;
                if (prop.HasAttribute<TableColumn>())
                {
                    parameters.Add(prop.Name, prop.GetValue(entity));
                }
            }
            var sp = new StoredProcedureModel(typeof(T), nameof(Add), parameters);
            _spQueue.Enqueue(sp);
        }

        public T? Get(object? id)
        {
            if (id == null) return null;
            var parameters = new Dictionary<string, object?>();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.HasAttribute<PrimaryKey>() && prop.HasAttribute<TableColumn>())
                {
                    parameters.Add(prop.Name, id);
                    break;
                }
            }
            var sp = new StoredProcedureModel(typeof(T), nameof(Get), parameters);
            var entity = _spCaller.GetRow<T>(sp);
            return entity;
        }

        public void Remove(object? id)
        {
            if (id == null) return;
            var parameters = new Dictionary<string, object?>();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.HasAttribute<PrimaryKey>() && prop.HasAttribute<TableColumn>())
                {
                    parameters.Add(prop.Name, id);
                    break;
                }
            }
            var sp = new StoredProcedureModel(typeof(T), nameof(Remove), parameters);
            _spQueue.Enqueue(sp);
        }

        public void CommitChanges()
        {
            while (_spQueue.Count > 0)
            {
                var sp = _spQueue.Dequeue();
                _spCaller.Execute(sp);
            }
        }

    }
}
