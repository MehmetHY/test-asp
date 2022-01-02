using TodoData.Data.Interfaces;
using TodoData.Repository.Interface;
using TodoModels.Models;
using Dapper;

namespace TodoData.Repository
{
    public class UserRepository : IRepository<UserModel>
    {
        private readonly IProcedureCaller _pc;
        public UserRepository(IProcedureCaller pc)
        {
            _pc = pc;
        }
        
        public void Add(UserModel entity)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Name", entity.Name, System.Data.DbType.String, System.Data.ParameterDirection.Input, 64);
            param.Add("Password", entity.Password, System.Data.DbType.String, System.Data.ParameterDirection.Input, 64);
            _pc.Execute("sp_user_add", param);
            foreach (var category in entity.Categories ?? new List<CategoryModel>())
            {
                // todo: add categories
            }
        }
        public UserModel? Get(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var entity = _pc.GetRow<UserModel>("sp_user_get_by_id", param);
            if (entity != null)
            {
                // todo: fill up category list
            }
            return entity;
        }
        public void Remove(int id)
        {
            var param = new DynamicParameters();
            param.Add("Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            _pc.Execute("sp_user_remove_by_id", param);
        }
    }
}
