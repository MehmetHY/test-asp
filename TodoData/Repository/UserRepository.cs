using TodoData.Data.Interfaces;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class UserRepository : Repository<UserModel>
    {
        public UserRepository(IProcedureCaller pc) : base(pc) {}
    }
}
