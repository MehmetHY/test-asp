using TodoUtils.ViewModels;
using TodoModels.Models;

namespace TodoUtils.Extensions
{
    public static class CategoryExtensions
    {
        public static CategoryModel ToCategoryModel(this CreateCategoryViewModel model)
        {
            var category = new CategoryModel
            {
                Name = model.NewCategoryName,
                UserId = model.UserId,
                BaseCategoryId = model.BaseCategoryId,
            };

            return category;
        }
    }
}
