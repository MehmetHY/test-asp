namespace DbAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        T? Get(object? id);
        void Add(T? entity);
        void Remove(object? id);
        void CommitChanges();
    }
}
