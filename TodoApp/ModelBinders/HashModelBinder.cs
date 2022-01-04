using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApp.Extensions;

namespace TodoApp.ModelBinders
{
    public class HashModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? context)
        {
            if (context == null)
                return Task.CompletedTask;

            var modelName = context.ModelName;

            if (string.IsNullOrWhiteSpace(modelName))
                modelName = context.OriginalModelName;

            if (string.IsNullOrWhiteSpace(modelName))
                return Task.CompletedTask;

            var pResult = context.ValueProvider.GetValue(modelName);

            if (pResult == ValueProviderResult.None)
                return Task.CompletedTask;


            context.ModelState.SetModelValue(modelName, pResult);
            var value = pResult.FirstValue;

            if (string.IsNullOrWhiteSpace(value))
                return Task.CompletedTask;

            context.Result = ModelBindingResult.Success(value.ToHashSha256());

            return Task.CompletedTask;
        }
    }
}
