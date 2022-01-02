using System.Data;

namespace TodoData.Factory.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection(string connectionString);
    }
}