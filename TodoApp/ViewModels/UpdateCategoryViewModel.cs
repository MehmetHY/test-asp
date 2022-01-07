using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class UpdateCategoryViewModel
    {
        public CategoryModel? Category { get; set; }
        public bool FromHome { get; set; } = true;
    }
}
