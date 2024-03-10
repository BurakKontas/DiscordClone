using CenteralService.Domain.Models;
using MediatR;

namespace CenteralService.Application.Behaviors
{
    public class ErrorHandlingAndLoggingBehavior<TRequest, TResponse>(ILogger logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestId = Guid.NewGuid();
            _logger.LogInformation("Handling {RequestType} RequestId: {requestId}", typeof(TRequest).Name, requestId);
            try
            {
                var response = await next();
                return response;
            } catch (Exception ex)
            {
                var message = $"Error handling {typeof(TRequest).Name}";
                _logger.LogError(ex, "{ErrorMessage} RequestId: {requestId}", message, requestId);
                throw new Exception(message, ex);
            } 
            finally
            {
                _logger.LogInformation("Handled {ResponseType} RequestId: {requestId}", typeof(TResponse).Name, requestId);
            }
        }
    }
}
