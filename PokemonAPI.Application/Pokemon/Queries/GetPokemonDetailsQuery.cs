using CommonAPI.Models;

namespace PokemonAPI.Application.Pokemon.Queries
{
    public class GetPokemonDetailsQuery : BaseDetailsQuery<GetPokemonDetailsFormRequest, GetPokemonDetailsFormResponse>
    {
        public GetPokemonDetailsQuery(GetPokemonDetailsFormRequest request) : base(request)
        {
        }
    }
}
