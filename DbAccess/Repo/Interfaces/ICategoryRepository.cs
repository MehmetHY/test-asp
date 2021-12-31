using TodoModels.Models;

namespace DbAccess.Repo.Interfaces
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        Task Update(CategoryModel category);
        Task Any(CategoryModel category);
        Task Any(int id);
        Task Any(string name);
        Task<IEnumerable<CategoryModel>> GetCategoriesOfUser(UserModel user);
        Task<IEnumerable<CategoryModel>> GetSubCategories(CategoryModel category);
    }
}
