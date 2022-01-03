using System.Data;

namespace DbAccess.Factory
{
    public abstract class ConnectionFactory
    {
        protected readonly string _connectionString;
        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public abstract IDbConnection CreateConnection();
    }
}