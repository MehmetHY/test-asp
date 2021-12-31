using DbAccess.Data.Interfaces;
using Dapper;
using MySqlConnector;

namespace DbAccess.Data
{
    public class MySqlDbContext : IDbContext
    {
        public string ConnectionString { get; }
        public MySqlDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task Execute<T>(string sql, T parameters)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
                return;
            }
        }

        public async Task<IEnumerable<T>> Query<T, U>(string sql, U parameters)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);
                return rows;
            }
        }
    }
}
