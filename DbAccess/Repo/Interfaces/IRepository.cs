using System.Linq.Expressions;

namespace DbAccess.Repo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Find(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            );

        Task<T?> FirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
            );

        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);

        Task Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
