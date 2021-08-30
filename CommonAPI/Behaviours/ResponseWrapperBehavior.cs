using CommonAPI.Exceptions;
using CommonAPI.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CommonAPI.Behaviours
{
    public class ResponseWrapperBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse> where TResponse : ResponseWrapper, new()
    {
        private readonly ILogger<ResponseWrapperBehavior<TRequest, TResponse>> _logger;

        public ResponseWrapperBehavior(ILogger<ResponseWrapperBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var response = default(TResponse);

            try
            {
                response = await next.Invoke();

                response.IsSuccess = true;
            }
            catch (BaseException ex)
            {
                if (response == null)
                {
                    response = new TResponse();
                }

                response.Error = new ResponseError
                {
                    IsLogicError = true,
                    Message = ex.Message
                };

                response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                var isLogicError = false;
                if (ex.InnerException != null)
                    errorMessage += " Inner Exception:" + ex.InnerException.Message;
                _logger.LogError(ex, errorMessage);

                if (response == null)
                {
                    response = new TResponse();
                }
                string message = "Server error occurred.";

                if (ex is ApplicationException)
                {
                    message = ex.Message;
                    isLogicError = true;
                }
                response.Error = new ResponseError
                {
                    IsLogicError = isLogicError,
                    Message = message
                };

                response.IsSuccess = false;
            }

            stopwatch.Stop();

            response.ProcessingTime = stopwatch.Elapsed;

            return response;
        }
    }
}
