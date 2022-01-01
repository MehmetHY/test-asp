using DbAccess.Data.Interfaces;
using DbAccess.Repo;
using TodoRepo.Repositories.Interfaces;
using TodoModels.Models;

namespace TodoRepo.Repositories
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) {}

        public Task<bool> Exists(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
