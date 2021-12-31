using System.Linq.Expressions;

namespace DbAccess.Repo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter);

        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);

        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
