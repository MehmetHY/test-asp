using System.Data;

namespace TodoData.Factory.Abstract
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