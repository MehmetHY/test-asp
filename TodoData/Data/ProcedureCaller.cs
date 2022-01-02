using TodoData.Data.Interfaces;
using TodoData.Data.Models;
using TodoData.Factory.Abstract;
using TodoData.Utils;

namespace TodoData.Data
{
    public class ProcedureCaller : IProcedureCaller
    {
        private readonly ConnectionFactory _connectionFactory;

        public ProcedureCaller(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Execute(StoredProcedureModel sp)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            connection.Exec(sp);
        }

        public T? GetValue<T>(StoredProcedureModel sp)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return connection.QueryValue<T>(sp);
        }

        public T? GetRow<T>(StoredProcedureModel sp)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return connection.QueryRow<T>(sp);
        }

        public IEnumerable<T> GetRows<T>(StoredProcedureModel sp)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return connection.QueryRows<T>(sp);
        }
    }
}
