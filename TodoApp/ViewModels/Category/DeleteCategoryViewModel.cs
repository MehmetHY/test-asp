using TodoModels.Models;

namespace TodoApp.ViewModels.Category
{
    public class DeleteCategoryViewModel
    {
        public int? Id { get; set; }
        
        public int? BaseId { get; set; }
        
        public int? UserId { get; set; }
        
        public bool FromHome { get; set; } = true;


        public void Import(CategoryModel model)
        {
            Id = model.Id;
            BaseId = model.BaseCategoryId;
            UserId = model.UserId;
        }
    }
}
