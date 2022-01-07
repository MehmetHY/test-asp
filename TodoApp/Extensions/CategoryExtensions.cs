using TodoApp.ViewModels;
using TodoModels.Models;

namespace TodoApp.Extensions
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
