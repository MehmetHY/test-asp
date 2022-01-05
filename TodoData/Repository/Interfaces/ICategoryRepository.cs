using DbAccess.Repository;
using TodoModels.Models;

namespace TodoData.Repository
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        IEnumerable<CategoryModel> GetOfUser(int userId);
        IEnumerable<CategoryModel> GetOfCategory(int? categoryId);
        bool UserHasCategory(int userId, string categoryName);
        CategoryModel? GetByName(int userId, string? categoryName);
    }
}
