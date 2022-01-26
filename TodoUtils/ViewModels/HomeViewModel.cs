using TodoModels.Models;

namespace TodoUtils.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryModel> Categories { get; }

        public CreateCategoryViewModel CreateCategoryModel { get; set; } = new();

        public HomeViewModel
            (
                IEnumerable<CategoryModel> categories,
                CreateCategoryViewModel createCategoryModel
            )
        {
            Categories = categories;
            CreateCategoryModel = createCategoryModel;
        }

    }
}
