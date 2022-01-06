using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryModel> Categories { get; }
        public HomeViewModel(IEnumerable<CategoryModel> categories)
        {
            Categories = categories;
        }

    }
}
