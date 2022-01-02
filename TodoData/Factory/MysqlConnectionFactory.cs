using System.Data;
using MySqlConnector;
using TodoData.Factory.Interfaces;

namespace TodoData.Factory
{
    public class MysqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}
