using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PokemonAPI.App;
using System;
using System.Threading.Tasks;

namespace PokemonAPI.ModelBinders
{
    public class ViewModelFromJsonQueryModelBinder : IModelBinder
    {
        private readonly FromJsonQueryAttribute _fromJsonQueryAttribute;

        public ViewModelFromJsonQueryModelBinder(FromJsonQueryAttribute fromJsonQueryAttribute)
        {
            _fromJsonQueryAttribute = fromJsonQueryAttribute;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var json = bindingContext.HttpContext.Request.Query[_fromJsonQueryAttribute.Name];

            var viewModel = DeserializeObject(json, bindingContext.ModelType);

            bindingContext.Result = ModelBindingResult.Success(viewModel);

            return Task.CompletedTask;
        }

        private object DeserializeObject(Microsoft.Extensions.Primitives.StringValues json, Type type)
        {
            if(typeof(string) == type)
            {
                return json.ToString();
            }
            return JsonConvert.DeserializeObject(json, type);
        }
    }
}
