using System.Data;
using MySqlConnector;
using TodoData.Factory.Abstract;

namespace TodoData.Factory
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
