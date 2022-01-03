using DbAccess.Data;
using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(IProcedureCaller pc) : base(pc)
        {
        }

        public bool NameExists(string name)
        {
            throw new NotImplementedException();
        }

        public bool PasswordCorrect(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
