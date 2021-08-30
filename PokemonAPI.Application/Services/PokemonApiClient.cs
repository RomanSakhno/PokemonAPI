using CommonAPI.Interfaces.Services;
using CommonAPI.Models;
using PokemonAPI.Application.Services.Enums;
using PokemonAPI.Application.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonAPI.Application.Services
{
    public class PokemonApiClient: BaseApiClient, IPokemonApiClient<Models.Pokemon>
    {
        private readonly Dictionary<PokemonsEnum, string> _methods;
        public PokemonApiClient(string baseUri, Dictionary<PokemonsEnum, string> methods) : base(baseUri) 
        {
            _methods = methods;
        }

        public async Task<Models.Pokemon> GetPokemonAsync(string name, CancellationToken cancelationToken)
        {
            var pSpec = await GetPokemonSpeciesAsync<PokemonSpecies>(name, cancelationToken);
            return new Models.Pokemon {
                Id = pSpec.Id,
                Name = pSpec.Name, 
                Description = String.Join(Environment.NewLine, pSpec.Flavor_text_entries.Where(x=>x.Language.Name == "en").Select(x=>x.Flavor_text)), 
                Habitat = pSpec.Habitat?.Name, 
                IsLegendaty = pSpec.Is_legendary 
            };
        }

        public async Task<PokemonSpecies> GetPokemonSpeciesAsync<PokemonSpecies>(string name, CancellationToken cancelationToken)
        {
            return await base.GetAsync<PokemonSpecies>($"{_methods[PokemonsEnum.PokemonSpecies]}/{name}/", cancelationToken);
        }
    }
}
