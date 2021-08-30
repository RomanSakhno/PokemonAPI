using System.Threading;
using System.Threading.Tasks;

namespace CommonAPI.Interfaces.Services
{
    public interface IPokemonApiClient<T>
    {
        Task<T> GetPokemonAsync(string name, CancellationToken cancelationToken);
        Task<N> GetPokemonSpeciesAsync<N>(string query, CancellationToken cancelationToken);
    }
}
