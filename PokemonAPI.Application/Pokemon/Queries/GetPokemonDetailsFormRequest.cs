using CommonAPI.Models.Request;

namespace PokemonAPI.Application.Pokemon.Queries
{
    public class GetPokemonDetailsFormRequest : FormRequest
    {
        public string Name { get; set; }
    }
}
