using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PokemonAPI.Internals;

namespace PokemonAPI.App
{
    public class WebJsonSerializerSettings
    {
        public static void Apply(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            settings.Converters.Add(new TrimStringJsonConverter());
            settings.Converters.Add(new IsoDateTimeConverter());
        }
    }
}
