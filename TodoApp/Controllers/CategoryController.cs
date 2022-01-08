using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.ViewModels.Factories;
using TodoApp.Extensions;
using TodoApp.ViewModels;
using TodoApp.Extensions.Validation;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class CategoryController : DataController
    {
        private readonly CategoryViewModelFactory _cvmFactory;

        public CategoryController(AppService service) : base(service)
        {
            _cvmFactory = service.CategoryViewModelFactory;
        }

        [ErrorReceiver]
        public IActionResult Index(int? categoryId)
        {
            var userId = this.GetCurrentAccountId();
            var model = _cvmFactory.CreateCategoryViewModel(userId, categoryId);

            return model == null ?
                RedirectToAction("Index", "Home") : View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Create(CreateCategoryViewModel? model)
        {
            // todo: remove user id from model and put here
            if (ModelState.Valid(model, UnitOfWork))
            {
                var category = model!.ToCategoryModel();
                UnitOfWork.CategoryRepo.Add(category);
                UnitOfWork.SaveChanges();
            }

            return model?.FromHome ?? true ? 
                RedirectToAction("Index", "Home") :
                RedirectToAction(nameof(Index), new { categoryId = model.BaseCategoryId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm(Name = "deleteModel")] DeleteCategoryViewModel? model)
        {
            if (model == null)
                return RedirectToAction("Index", "Home");

            var userId = this.GetCurrentAccountId();

            if (UnitOfWork.CategoryRepo.UserHasCategory(userId, model.CategoryId))
            {
                UnitOfWork.CategoryRepo.Remove(model.CategoryId);
                UnitOfWork.SaveChanges();
            }

            return model.FromHome ?
                RedirectToAction("Index", "Home") :
                RedirectToAction(nameof(Index), new { categoryId = model.BaseCategoryId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ErrorSender]
        public IActionResult Update([FromForm(Name = "updateModel")] UpdateCategoryViewModel? model)
        {
            if (ModelState.Valid(model, UnitOfWork))
                UnitOfWork.CategoryRepo.Update(model!.Category);

            return model?.FromHome ?? true ?
                RedirectToAction("Index", "Home") :
                RedirectToAction(nameof(Index), new { categoryId = model.Category?.BaseCategoryId });
        }
    }
}
