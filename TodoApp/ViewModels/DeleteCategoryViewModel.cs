namespace TodoApp.ViewModels
{
    public class DeleteCategoryViewModel
    {
        public int? Id { get; set; }
        
        public int? BaseId { get; set; }
        
        public int? UserId { get; set; }
        
        public bool FromHome { get; set; } = true;
    }
}
