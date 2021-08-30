using CommonAPI.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace CommonAPI.Models
{
    public abstract class BaseDetailsRequestHandler<TQuery, TRequest, TResponse, TViewModel>
        : BaseRequestHandler<TQuery, ResponseWrapper<TResponse>>
        where TQuery : BaseDetailsQuery<TRequest, TResponse>
        where TResponse : FormResponse<TViewModel>, new()
        where TRequest : class
        where TViewModel : class
    {
        public override async Task<ResponseWrapper<TResponse>> Handle(TQuery qr, CancellationToken cancellationToken)
        {
            ResponseWrapper<TResponse> response = new ResponseWrapper<TResponse>();
            TResponse responseData = await BuildBaseResponseData(qr.Request, cancellationToken);
            responseData = await AdditionalLogic(qr, responseData, cancellationToken);

            response.Data = responseData;
            return response;
        }

        protected virtual Task<TResponse> AdditionalLogic(TQuery requestQuery, TResponse response, CancellationToken cancellationToken)
        {
            return Task.FromResult(response);
        }

        protected abstract Task<TResponse> BuildBaseResponseData(TRequest request, CancellationToken cancellationToken);
    }
}
