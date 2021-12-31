using System.Linq.Expressions;

namespace DbAccess.Data.Interfaces
{
    public interface IDbContext
    {
        string ConnectionString { get; }
        
        Task Execute<T>(string sql, T parameters);
        Task<IEnumerable<T>> Query<T, U>(string comsqlmand, U parameters);

        Task<T> Get<T>(int id);
        Task<IEnumerable<T>> GetAll<T>();
        Task<IEnumerable<T>> Find<T>(Expression<Func<T, bool>> filter);

        Task Add<T>(T entity);
        Task AddRange<T>(IEnumerable<T> entities);

        Task Remove<T>(T entity);
        Task RemoveRange<T>(IEnumerable<T> entities);
    }
}
