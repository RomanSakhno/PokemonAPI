using MediatR;

namespace CommonAPI.Models
{
    public class BaseDetailsQuery<TRequest, TResponse> : IRequest<ResponseWrapper<TResponse>>
    {
        public TRequest Request { get; set; }

        public BaseDetailsQuery(TRequest request)
        {
            Request = request;
        }
    }
}
