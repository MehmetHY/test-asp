using TodoModels.Models;
using DbAccess.Repo.Interfaces;

namespace TodoModels.Repositories
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task Update(UserModel user);
        Task<bool> Exists(UserModel user);
        Task<bool> Exists(int id);
        Task<bool> Exists(string name);
    }
}
