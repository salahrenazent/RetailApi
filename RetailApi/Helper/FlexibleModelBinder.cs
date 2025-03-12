using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text.Json;

namespace RetailApi.Helper
{
    public class FlexibleModelBinder:IModelBinder
    {

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            using (var reader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                var json = await reader.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(json))
                {
                    bindingContext.Result = ModelBindingResult.Success(Activator.CreateInstance(bindingContext.ModelType));
                    return;
                }

                try
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    };

                    var model = JsonConvert.DeserializeObject(json, bindingContext.ModelType, settings);
                    bindingContext.Result = ModelBindingResult.Success(model);
                }
                catch (Exception ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid JSON format: " + ex.Message);
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }
        }
    }
}
