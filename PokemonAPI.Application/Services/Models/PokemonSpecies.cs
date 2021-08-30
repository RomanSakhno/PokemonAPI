using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonAPI.Application.Services.Models
{
    public class PokemonSpecies
    {
        [JsonProperty("id")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Id { get; set; }

        [JsonProperty("name")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public string Name { get; set; }

        [JsonProperty("order")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Order { get; set; }

        [JsonProperty("gender_rate")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Gender_rate { get; set; }

        [JsonProperty("capture_rate")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Capture_rate { get; set; }

        [JsonProperty("base_happiness")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Base_happiness { get; set; }

        [JsonProperty("is_baby")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public bool Is_baby { get; set; }

        [JsonProperty("is_legendary")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public bool Is_legendary { get; set; }

        [JsonProperty("is_mythical")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public bool Is_mythical { get; set; }

        [JsonProperty("hatch_counter")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public int Hatch_counter { get; set; }

        [JsonProperty("has_gender_differences")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public bool Has_gender_differences { get; set; }

        [JsonProperty("forms_switchable")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public bool Forms_switchable { get; set; }

        [JsonProperty("habitat")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public PokemonHabitat Habitat { get; set; }

        [JsonProperty("form_descriptions")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public List<PokemonFormDescriptions> Form_descriptions { get; set; }

        [JsonProperty("flavor_text_entries")] //just for NUnits for application using CamelCasePropertyNamesContractResolver setting in WebJsonSerializerSettings
        public List<PokemonFlavorText> Flavor_text_entries { get; set; }
    }
}
