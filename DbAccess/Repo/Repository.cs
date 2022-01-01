using DbAccess.Repo.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DbAccess.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> dbSet;

        public Repository(DbContext db)
        {
            dbSet = db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                var properties = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>>? filter = default, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                var properties = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T?> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Remove(int id)
        {
            T? entity = await Get(id);
            
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
