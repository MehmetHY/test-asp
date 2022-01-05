using TodoData.UnitOfWork;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryNode
    {
        private CategoryNode? _parent;
        public CategoryModel Category { get; private set; }
        public List<CategoryNode> Children { get; private set; } = new();
        public CategoryNode? Parent
        {
            get { return _parent; }
            private set 
            {
                _parent?.Children.Remove(this);
                _parent = value;
                _parent?.Children.Add(this);
            }
        }

        public CategoryNode(CategoryModel model, CategoryNode? parent = null)
        {
            Category = model;
            Parent = parent;
        }

        public void Load(UnitOfWork unitOfWork)
        {
            var children = unitOfWork.CategoryRepo.GetOfCategory(Category.Id!.Value);
            foreach (var child in children)
            {
                var childNode = new CategoryNode(child, this);
                childNode.Load(unitOfWork);
                Children.Add(childNode);
            }
        }
    }

    public class HomeViewModel
    {
        public List<CategoryNode> Categories { get; set; } = new();
        public void Load(int userId, UnitOfWork unitOfWork)
        {
            var categories = unitOfWork.CategoryRepo.GetOfUser(userId);
            foreach (var category in categories)
            {
                var categoryNode = new CategoryNode(category);
                categoryNode.Load(unitOfWork);
                Categories.Add(categoryNode);
            }
        }
    }
}
