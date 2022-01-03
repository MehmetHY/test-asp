using DbAccess.Data;
using TodoData.Repository;

namespace TodoData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserRepository UserRepo { get; }
        public UnitOfWork(IProcedureCaller pc)
        {
            UserRepo = new UserRepository(pc);
        }

        public void SaveChanges()
        {
            UserRepo.CommitChanges();
        }
    }
}
