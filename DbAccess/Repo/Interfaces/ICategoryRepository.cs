using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoModels.Models;

namespace DbAccess.Repo.Interfaces
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        Task Update(CategoryModel category);
        Task Exist(CategoryModel category);
        Task Exist(int id);
        Task Exist(string name);
        Task<IEnumerable<CategoryModel>> GetCategoriesOfUser(UserModel user);
        Task<IEnumerable<CategoryModel>> GetSubCategories(CategoryModel category);
    }
}
