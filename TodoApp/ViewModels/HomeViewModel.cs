using Microsoft.AspNetCore.Mvc;
using TodoData.UnitOfWork;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class HomeViewModel
    {
        public CategoryModel? Category { get; set; } = null;
        public List<CategoryModel> Categories { get; set; } = new();
        public List<TodoModel> Todos { get; set; } = new();
    }
}
