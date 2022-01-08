namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public CreateCategoryViewModel CreateCategoryViewModel { get; set; } = new();
        public UpdateCategoryViewModel UpdateCategoryViewModel { get; set; } = new();
        public DeleteCategoryViewModel DeleteCategoryViewModel { get; set; } = new();
    }
}
