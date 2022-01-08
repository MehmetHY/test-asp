using TodoModels.Models;

namespace TodoUtils.ViewModels
{
    public class UpdateCategoryViewModel
    {
        public CategoryModel? Category { get; set; }
        public bool FromHome { get; set; } = true;
    }
}
