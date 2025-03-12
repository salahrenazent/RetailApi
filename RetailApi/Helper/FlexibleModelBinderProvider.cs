using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace RetailApi.Helper
{
    public class FlexibleModelBinderProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            // Use default model binding for primitive types
            if (context.Metadata.ModelType.IsPrimitive || context.Metadata.ModelType == typeof(string))
            {
                return null; // Use default binder
            }

            return new FlexibleModelBinder(); // Ensure FlexibleModelBinder implements IModelBinder
        }
    }
}
