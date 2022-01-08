using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TodoUtils.ModelBinders
{
    public class TrimModelBinder : IModelBinder
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
            value = value?.Trim() ?? string.Empty;
            context.Result = ModelBindingResult.Success(value);

            return Task.CompletedTask;
        }
    }
}
