using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonAPI.Application.Services.Models
{
    public class PokemonHabitat
    {
        [JsonProperty("id")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Id { get; set; }

        [JsonProperty("name")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Name { get; set; }

        [JsonProperty("names")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public List<HabitatNameItem> Names { get; set; }
    }

    public class HabitatNameItem
    {
        [JsonProperty("name")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Name { get; set; }

        [JsonProperty("language")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public List<Language> Language { get; set; }
    }

    public class Language
    {
        [JsonProperty("id")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Id { get; set; }

        [JsonProperty("name")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Name { get; set; }

        [JsonProperty("official")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public bool Official { get; set; }

        [JsonProperty("iso639")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Iso639 { get; set; }
        
        [JsonProperty("iso3166")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Iso3166 { get; set; }

        [JsonProperty("names")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public List<HabitatNameItem> Names { get; set; }
    }
}
