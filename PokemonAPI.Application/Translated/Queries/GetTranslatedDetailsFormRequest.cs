using CommonAPI.Models.Request;

namespace PokemonAPI.Application.Translated.Queries
{
    public class GetTranslatedDetailsFormRequest : FormRequest
    {
        public string Name { get; set; }
    }
}
