using Dapper;
using TodoData.Data.Interfaces;
using TodoData.Repository.Interface;
using TodoModels.Attributes;
using TodoModels.Utils;
using System.Data;

namespace TodoData.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IProcedureCaller _pc;
        public Repository(IProcedureCaller pc)
        {
            _pc = pc;
        }

        public void Add(T? entity)
        {
            if (entity == null) return;

            DynamicParameters parameters = new DynamicParameters();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.HasAttribute<PrimaryKey>()) continue;

                if (prop.HasAttribute<TableColumn>())
                {
                    var attr = prop.GetAttribute<TableColumn>();
                    parameters.Add(prop.Name, prop.GetValue(entity), attr!.DataType, ParameterDirection.Input);
                }

                string procName = $"SP_{typeof(T).Name}_Add";
                _pc.Execute(procName, parameters);
            }
        }

        public T? Get(object? id)
        {
            if (id == null) return null;

            DynamicParameters parameters = new DynamicParameters();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.HasAttribute<PrimaryKey>() && prop.HasAttribute<TableColumn>())
                {
                    var attr = prop.GetAttribute<TableColumn>();
                    parameters.Add(prop.Name, id, attr!.DataType, ParameterDirection.Input);
                    break;
                }
            }

            string procName = $"SP_{typeof(T).Name}_Get";
            return _pc.GetRow<T>(procName, parameters);
        }

        public void Remove(object? id)
        {
            if (id == null) return;

            DynamicParameters parameters = new DynamicParameters();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.HasAttribute<PrimaryKey>() && prop.HasAttribute<TableColumn>())
                {
                    var attr = prop.GetAttribute<TableColumn>();
                    parameters.Add(prop.Name, id, attr!.DataType, ParameterDirection.Input);
                    break;
                }
            }

            string procName = $"SP_{typeof(T).Name}_Remove";
            _pc.Execute(procName, parameters);
        }
    }
}
