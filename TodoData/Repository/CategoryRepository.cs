using DbAccess.Data.Interfaces;
using TodoModels.Models;
using DbAccess.Repository;

namespace TodoData.Repository
{
    public class CategoryRepository : Repository<CategoryModel>
    {
        public CategoryRepository(IProcedureCaller pc) : base(pc) {}
        
    }
}
