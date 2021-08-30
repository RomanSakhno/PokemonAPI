using Newtonsoft.Json;

namespace PokemonAPI.Application.Services.Models
{
    public class TranslatedSuccess
    {
        [JsonProperty("total")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Total { get; set; }
    }
    public class TranslatedContents
    {
        [JsonProperty("translated")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Translated { get; set; }
        
        [JsonProperty("text")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Text { get; set; }

        [JsonProperty("translation")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Translation { get; set; }
    }
    public class TranslatedResponse
    {
        [JsonProperty("success")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public TranslatedSuccess Success { get; set; }

        [JsonProperty("contents")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public TranslatedContents Contents { get; set; }
    }
}
