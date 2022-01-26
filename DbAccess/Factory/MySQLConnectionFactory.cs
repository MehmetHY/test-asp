using System.Data;
using MySqlConnector;

namespace DbAccess.Factory
{
    public class MySQLConnectionFactory : ConnectionFactory
    {
        public MySQLConnectionFactory(string connectionString) : base(connectionString)
        {
        }
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
