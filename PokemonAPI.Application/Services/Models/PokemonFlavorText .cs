using Newtonsoft.Json;

namespace PokemonAPI.Application.Services.Models
{
    public class PokemonFlavorText
    {
        [JsonProperty("flavor_text")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings 
        public string Flavor_text { get; set; }

        [JsonProperty("language")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public Language Language { get; set; }
    }
}
