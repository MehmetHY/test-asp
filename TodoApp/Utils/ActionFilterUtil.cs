using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoApp.Utils
{
    public static class ActionFilterUtil
    {
        public static bool HasFilter<T>(this ActionDescriptor descriptor) 
            where T : ActionFilterAttribute
        {
            bool result = descriptor.EndpointMetadata.
                Any(
                    o => o.GetType() == typeof(T)
                );
            return result; 
        }
    }
}
