using TodoModels.Models;
using DbAccess.Repo.Interfaces;

namespace TodoRepo.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        Task Update(CategoryModel category);
        Task Any(string name);
        Task<IEnumerable<CategoryModel>> GetCategoriesOfUser(UserModel user);
        Task<IEnumerable<CategoryModel>> GetSubCategories(CategoryModel category);
    }
}
