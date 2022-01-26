namespace TodoUtils.ViewModels
{
    public class DeleteCategoryViewModel
    {
        public int CategoryId { get; set; }
        public int? BaseCategoryId { get; set; }
        public bool FromHome { get; set; } = true;
    }
}
