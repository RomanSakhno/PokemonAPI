using CommonAPI.Interfaces.Services;
using CommonAPI.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonAPI.Application.Pokemon.Queries
{
    public class GetPokemonDetailsQueryHandler : BaseDetailsRequestHandler<
        GetPokemonDetailsQuery, 
        GetPokemonDetailsFormRequest, 
        GetPokemonDetailsFormResponse, 
        GetPokemonDetailsViewModel>
    {
        private readonly IPokemonApiClient<Services.Models.Pokemon> _pokemonApiClient;
        public GetPokemonDetailsQueryHandler(IPokemonApiClient<Services.Models.Pokemon> pokemonApiClient)
        {
            _pokemonApiClient = pokemonApiClient;
        }

        protected override async Task<GetPokemonDetailsFormResponse> BuildBaseResponseData(GetPokemonDetailsFormRequest request, CancellationToken cancellationToken)
        {
            var p = await _pokemonApiClient.GetPokemonAsync(request.Id.HasValue ? request.Id.ToString() : request.Name, cancellationToken);
            return new GetPokemonDetailsFormResponse
            {
                Form = new GetPokemonDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Habitat = p.Habitat,
                    IsLegendary = p.IsLegendaty
                }
            };
        }
    }
}
