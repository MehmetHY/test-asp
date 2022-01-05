using DbAccess.Data;
using TodoData.Repository;

namespace TodoData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserRepository UserRepo { get; }
        public CategoryRepository CategoryRepo { get; }
        public UnitOfWork(IProcedureCaller pc)
        {
            UserRepo = new UserRepository(pc);
            CategoryRepo = new CategoryRepository(pc);
        }

        public void SaveChanges()
        {
            UserRepo.CommitChanges();
            CategoryRepo.CommitChanges();
        }
    }
}
