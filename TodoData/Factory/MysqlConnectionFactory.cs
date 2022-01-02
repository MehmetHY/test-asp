using System.Data;
using MySqlConnector;
using TodoData.Factory.Abstract;

namespace TodoData.Factory
{
    public class MysqlConnectionFactory : ConnectionFactory
    {
        public MysqlConnectionFactory(string connectionString) : base(connectionString)
        {
        }
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
