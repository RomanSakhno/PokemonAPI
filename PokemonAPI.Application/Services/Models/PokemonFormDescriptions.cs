using Newtonsoft.Json;

namespace PokemonAPI.Application.Services.Models
{
    public class PokemonFormDescriptions
    {
        [JsonProperty("description")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Description { get; set; }

        [JsonProperty("language")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public Language Language {get; set; }
    }
}
