using Microsoft.AspNetCore.Mvc;
using TodoApp.ActionFilters;
using TodoApp.Services;
using TodoApp.Extensions.ControllerExtensions;

namespace TodoApp.Controllers
{
    [AuthUserFilter]
    public class ContentController : DataController
    {
        public ContentController(AppService service) : base(service) {}

        [ErrorReceiver]
        public IActionResult Index(int? categoryId) => this.ProceedToContentPage(categoryId);
    }
}
