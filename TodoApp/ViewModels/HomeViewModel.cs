using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class HomeViewModel
    {
        public CategoryModel? Category { get; set; } = null;
        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
