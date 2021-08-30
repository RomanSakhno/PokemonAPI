using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using PokemonAPI.ModelBinders;
using System.Linq;

namespace PokemonAPI.App
{
    public class CustomIModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata is DefaultModelMetadata defaultMetadata)
            {
                var fromJsonQueryAttribute = defaultMetadata.Attributes.Attributes.FirstOrDefault(x => x is FromJsonQueryAttribute);

                if (fromJsonQueryAttribute != null)
                {
                    return new ViewModelFromJsonQueryModelBinder(fromJsonQueryAttribute as FromJsonQueryAttribute);
                }
            }


            return null;
        }
    }
}
