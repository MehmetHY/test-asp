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

        public bool NameExists(string name)
        {
            var parameters = new Dictionary<string, object?>();
            parameters.Add("name", name);
            var sp = new StoredProcedureModel(typeof(UserModel), nameof(NameExists), parameters);
            var result = _spCaller.GetValue<bool>(sp);
            return result;
        }

        public bool PasswordCorrect(UserModel? model)
        {
            if (model == null || model.Password == null) return false;
            var parameters = new Dictionary<string, object?>();
            parameters.Add("password", model.Password);
            var sp = new StoredProcedureModel(typeof(UserModel), nameof(PasswordCorrect), parameters);
            var result = _spCaller.GetValue<bool>(sp);
            return result;
        }
    }
}
