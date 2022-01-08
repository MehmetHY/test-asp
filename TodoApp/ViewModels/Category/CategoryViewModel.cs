using TodoModels.Models;

namespace TodoApp.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? UserId { get; set; }
        public int? BaseCategoryId { get; set; }
        public bool FromHome { get; set; } = true;

        public void Import(CategoryModel? model, bool fromHome = true)
        {
            if (model == null)
                return;

            Id = model.Id;
            Name = model.Name;
            UserId = model.UserId;
            BaseCategoryId = model.BaseCategoryId;
            FromHome = fromHome;
        }
    }
}
