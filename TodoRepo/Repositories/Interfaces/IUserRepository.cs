using TodoModels.Models;
using DbAccess.Repo.Interfaces;

namespace TodoRepo.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task Update(UserModel user);
        Task<bool> Exists(int id);
        Task<bool> Exists(string name);
    }
}
