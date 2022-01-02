using Dapper;
using System.Data;
using TodoData.Data.Interfaces;
using TodoData.Factory.Abstract;

namespace TodoData.Data
{
    public class ProcedureCaller : IProcedureCaller
    {
        private readonly ConnectionFactory _connectionFactory;

        public ProcedureCaller(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Execute(string procedureName, DynamicParameters? parameters = null)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                connection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T? GetValue<T>(string procedureName, DynamicParameters? parameters = null)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                var value = connection.ExecuteScalar<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return (T?)Convert.ChangeType(value, typeof(T?));
            }
        }

        public T? GetRow<T>(string procedureName, DynamicParameters? parameters = null)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                var row = connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return (T?)Convert.ChangeType(row, typeof(T?));
            }
        }

        public IEnumerable<T> GetRows<T>(string procedureName, DynamicParameters? parameters = null)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                var query = connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }
    }
}
