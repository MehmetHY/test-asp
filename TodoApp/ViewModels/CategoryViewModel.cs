namespace TodoApp.ViewModels
{
    public class CategoryViewModel
    {
        public CreateCategoryViewModel CreateCategoryViewModel { get; set; } = new();
        public UpdateCategoryViewModel UpdateCategoryViewModel { get; set; } = new();
        public DeleteCategoryViewModel DeleteCategoryViewModel { get; set; } = new();

        public static class Factory
        {
            public static CategoryViewModel Create(int? userId, bool fromHome)
            {
                var createModel = new CreateCategoryViewModel
                {
                    UserId = userId,
                    FromHome = fromHome
                };

                var updateModel = new UpdateCategoryViewModel
                {
                    UserId = userId,
                    FromHome = fromHome
                };

                var deleteModel = new DeleteCategoryViewModel
                {
                    UserId = userId,
                    FromHome = fromHome
                };

                var model = new CategoryViewModel
                {
                    CreateCategoryViewModel = createModel,
                    UpdateCategoryViewModel = updateModel,
                    DeleteCategoryViewModel = deleteModel
                };

                return model;
            }
        }
    }
}
