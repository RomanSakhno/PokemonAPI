using Newtonsoft.Json;

namespace PokemonAPI.Application.Services.Models
{
    public class TranslatedRequest
    {
        [JsonProperty("text")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Text { get; set; }
    }
}
