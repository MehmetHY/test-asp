using DbAccess.Repo.Interfaces;
using DbAccess.Data.Interfaces;
using System.Linq.Expressions;

namespace DbAccess.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter)
        {
            var rows = await _dbContext.Find(filter);
            return rows;
        }
        public async Task<T> Get(int id)
        {
            var entity = await _dbContext.Get<T>(id);
            return entity;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var entites = await _dbContext.GetAll<T>();
            return entites;
        }

        public async Task Add(T entity)
        {
            await _dbContext.Add(entity);
            return;
        }
        public async Task AddRange(IEnumerable<T> entities)
        {
            await _dbContext.AddRange(entities);
            return;
        }

        public async Task Remove(T entity)
        {
            await _dbContext.Remove(entity);
            return;
        }
        public async Task RemoveRange(IEnumerable<T> entities)
        {
            await _dbContext.RemoveRange(entities);
        }
    }
}
