using TodoModels.Models;

namespace DbAccess.Repo.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task Update(UserModel model);
        Task<bool> Exists(int id);
        Task<bool> Exists(string name);
    }
}
