using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        IEnumerable<CategoryModel> GetOfUser(int? userId);
        IEnumerable<CategoryModel> GetOfCategory(int? categoryId);
        bool UserHasCategory(int? userId, int? categoryId);
        CategoryModel? GetByName(int? userId, string? categoryName);
        bool NameExists(int? userId, string? name);
    }
}
