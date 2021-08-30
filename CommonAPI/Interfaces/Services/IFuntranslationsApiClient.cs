using System.Threading;
using System.Threading.Tasks;

namespace CommonAPI.Interfaces.Services
{
    public interface IFuntranslationsApiClient<T>
    {
        Task<N> PostTranslated<N>(int method, string body, CancellationToken cancelationToken);
    }
}
