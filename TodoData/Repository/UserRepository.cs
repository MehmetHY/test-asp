using DbAccess.Data;
using DbAccess.Data.Models;
using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(IProcedureCaller pc) : base(pc)
        {
        }

        public UserModel? GetByName(string name)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(name), name }
            };
            var sp = new StoredProcedureModel(typeof(UserModel), nameof(GetByName), parameters);
            var result = _spCaller.GetRow<UserModel>(sp);
            return result;
        }

        public bool NameExists(string name)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(name), name }
            };
            var sp = new StoredProcedureModel(typeof(UserModel), nameof(NameExists), parameters);
            var result = _spCaller.GetValue<bool>(sp);
            return result;
        }

        public bool PasswordCorrect(string? name, string? password)
        {
            if (name == null || password == null) return false;
            var parameters = new Dictionary<string, object?>
            {
                { nameof(name), name },
                { nameof(password), password }
            };
            var sp = new StoredProcedureModel(typeof(UserModel), nameof(PasswordCorrect), parameters);
            var result = _spCaller.GetValue<bool>(sp);
            return result;
        }
    }
}
