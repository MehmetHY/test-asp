using DbAccess.Data;
using DbAccess.Data.Models;
using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(IProcedureCaller pc) : base(pc)
        {
        }

        public IEnumerable<CategoryModel> GetOfCategory(int categoryId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(categoryId), categoryId }
            };
            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(GetOfCategory), parameters);
            var result = _spCaller.GetRows<CategoryModel>(sp);
            return result;
        }

        public IEnumerable<CategoryModel> GetOfUser(int userId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(userId), userId }
            };
            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(GetOfUser), parameters);
            var result = _spCaller.GetRows<CategoryModel>(sp);
            return result;
        }
    }
}
