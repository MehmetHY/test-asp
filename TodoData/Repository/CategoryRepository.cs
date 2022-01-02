using TodoData.Data.Interfaces;
using TodoData.Repository.Interface;
using TodoModels.Models;
using Dapper;

namespace TodoData.Repository
{
    public class CategoryRepository : IRepository<CategoryModel>
    {
        private readonly IProcedureCaller _pc;
        public CategoryRepository(IProcedureCaller pc)
        {
            _pc = pc;
        }
        
        public void Add(CategoryModel entity)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Name", entity.Name, System.Data.DbType.String, System.Data.ParameterDirection.Input, 64);
            param.Add("Password", entity.Password, System.Data.DbType.String, System.Data.ParameterDirection.Input, 64);
            _pc.Execute("sp_category_add", param);
            foreach (var category in entity.Categories ?? new List<CategoryModel>())
            {
                // todo: add categories
            }
        }

        public void AddRange(IEnumerable<CategoryModel> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public CategoryModel? Get(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var entity = _pc.GetRow<CategoryModel>("sp_category_get_by_id", param);
            if (entity != null)
            {
                // todo: fill up category list
            }
            return entity;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            var categorys = _pc.GetRows<CategoryModel>("sp_category_get_all");
            foreach (var category in categorys)
            {
                // todo: fill up category list
            }
            return categorys;
        }

        public void Remove(int id)
        {
            var param = new DynamicParameters();
            param.Add("Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            _pc.Execute("sp_category_remove_by_id", param);
        }

        public void Remove(CategoryModel entity)
        {
            Remove(entity.Id ?? -1);
        }

        public void RemoveAll()
        {
            _pc.Execute("sp_category_remove_all");
        }

        public void RemoveRange(IEnumerable<CategoryModel> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }
    }
}
