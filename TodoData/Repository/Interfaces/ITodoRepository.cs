using TodoModels.Models;

namespace TodoData.Repository
{
    public interface ITodoRepository
    {
        IEnumerable<TodoModel> GetOfUser(int? userId);
        IEnumerable<TodoModel> GetOfCategory(int? categoryId);
        IEnumerable<TodoModel> GetOfCategoryByName(int? userId, string? categoryName);
        void Update(TodoModel? model);
        TodoModel? GetByIndex(int? index, int? categoryId, int? userId);
        TodoModel? GetUpperNeighbour(int? index, int? categoryId, int? userId);
        TodoModel? GetLowerNeighbour(int? index, int? categoryId, int? userId);
    }
}
