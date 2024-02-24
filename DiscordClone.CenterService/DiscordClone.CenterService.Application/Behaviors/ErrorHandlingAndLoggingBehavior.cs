using DiscordClone.CenterService.Domain.Models;
using MediatR;

namespace DiscordClone.CenterService.Application.Behaviors
{
    public class ErrorHandlingAndLoggingBehavior<TRequest, TResponse>(Serilog.ILogger logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly Serilog.ILogger _logger = logger
                .ForContext<ErrorHandlingAndLoggingBehavior<TRequest, TResponse>>();

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var startTime = DateTime.UtcNow;
            var requestId = Guid.NewGuid();
            var log = _logger.ForContext("Request", request, destructureObjects: true);
            log = log.ForContext("RequestId", requestId, destructureObjects: true);
            log.Information("Handling {RequestType} RequestId: {requestId}", typeof(TRequest).Name, requestId);
            try
            {
                var response = await next();
                log = log.ForContext("Response", response, destructureObjects: true);
                return response;
            } catch (Exception ex)
            {
                var message = $"Error handling {typeof(TRequest).Name}";
                log.Error(ex, "{ErrorMessage} RequestId: {requestId}", message, requestId);
                throw new Exception(message, ex);
            } 
            finally
            {
                var endTime = DateTime.UtcNow;
                log = log.ForContext("TimeTaken", endTime - startTime, destructureObjects: true);
                log.Information("Handled {ResponseType} RequestId: {requestId}", typeof(TResponse).Name, requestId);
            }
        }
    }
}
