using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommonAPI.Models
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest query, CancellationToken cancellationToken);
    }
}
