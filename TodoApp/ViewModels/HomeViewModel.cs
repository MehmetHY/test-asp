using TodoData.UnitOfWork;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class CategoryNode
    {
        public CategoryModel Category { get; private set; }
        public List<CategoryNode> ChildNodes { get; private set; } = new();

        public CategoryNode? ParentNode { get; private set; }

        public CategoryNode(CategoryModel model, CategoryNode? parent = null)
        {
            Category = model;
            ParentNode = parent;
        }

        public void Load(UnitOfWork unitOfWork)
        {
            var children = unitOfWork.CategoryRepo.GetOfCategory(Category.Id!.Value);
            foreach (var child in children)
            {
                var childNode = new CategoryNode(child, this);
                childNode.Load(unitOfWork);
                ChildNodes.Add(childNode);
            }
        }
    }

    public class HomeViewModel
    {
        public List<CategoryNode> CategoryNodes { get; private set; } = new();
        public void Load(int userId, UnitOfWork unitOfWork)
        {
            var categories = unitOfWork.CategoryRepo.GetOfUser(userId);
            foreach (var category in categories)
            {
                var categoryNode = new CategoryNode(category);
                categoryNode.Load(unitOfWork);
                CategoryNodes.Add(categoryNode);
            }
        }
    }
}
