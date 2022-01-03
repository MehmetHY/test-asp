using DbAccess.Data.Interfaces;
using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class UserRepository : Repository<UserModel>
    {
        public UserRepository(IProcedureCaller pc) : base(pc) {}
    }
}
