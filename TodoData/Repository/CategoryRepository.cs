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

        public IEnumerable<CategoryModel> GetOfCategory(int? categoryId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(categoryId), categoryId }
            };
            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(GetOfCategory), parameters);
            var result = _spCaller.GetRows<CategoryModel>(sp);
            return result;
        }

        public CategoryModel? GetByName(int? userId, string? categoryName)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(userId), userId },
                { nameof(categoryName), categoryName }
            };
            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(GetByName), parameters);
            var result = _spCaller.GetRow<CategoryModel>(sp);
            return result;
        }

        public IEnumerable<CategoryModel> GetOfUser(int? userId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(userId), userId }
            };
            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(GetOfUser), parameters);
            var result = _spCaller.GetRows<CategoryModel>(sp);
            return result;
        }

        public bool UserHasCategory(int? userId, int? categoryId)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(userId), userId },
                { nameof(categoryId), categoryId }
            };
            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(UserHasCategory), parameters);
            var result = _spCaller.GetValue<bool>(sp);
            return result;
        }


        public bool NameExists(int? userId, string? name)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(userId), userId },
                { nameof(name), name },
            };

            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(NameExists), parameters);
            var result = _spCaller.GetValue<bool>(sp);

            return result;
        }

        public bool NameExistsInCategory(int? baseCategoryId, string? name)
        {
            var parameters = new Dictionary<string, object?>
            {
                { nameof(baseCategoryId), baseCategoryId },
                { nameof(name), name },
            };

            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(NameExistsInCategory), parameters);
            var result = _spCaller.GetValue<bool>(sp);

            return result;
        }

        public void Update(CategoryModel? model)
        {
            if (model == null || model.Id == null)
                return;

            var parameters = new Dictionary<string, object?>
            {
                { nameof(model.Id), model.Id },
                { nameof(model.Name), model.Name }
            };

            var sp = new StoredProcedureModel(typeof(CategoryModel), nameof(Update), parameters);

            _spCaller.Execute(sp);
        }
    }
}
