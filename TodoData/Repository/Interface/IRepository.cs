namespace TodoData.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T? Get(int id);
        IEnumerable<T> GetAll();

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(int id);
        void Remove(T entity);
        void RemoveAll();
        void RemoveRange(IEnumerable<T> entities);
    }
}
