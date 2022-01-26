using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        bool NameExists(string name);
        bool PasswordCorrect(string? name, string? password);
        UserModel? GetByName(string name);
    }
}
