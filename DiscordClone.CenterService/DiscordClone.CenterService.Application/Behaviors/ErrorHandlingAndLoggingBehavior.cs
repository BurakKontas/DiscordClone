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
             var requestId = Guid.NewGuid();
             var log = _logger.ForContext("Request", request, destructureObjects: true);
             log = log.ForContext("RequestId", requestId, destructureObjects: true);
             log.Information("Handling {RequestType} RequestId: {requestId}", typeof(TRequest).Name, requestId);
            try
            {

                var response = await next();

                log = log.ForContext("Response", response, destructureObjects: true);
                log.Information("Handled {ResponseType} RequestId: {requestId}", typeof(TResponse).Name, requestId);
                return response;
            } catch (Exception ex)
            {
                var message = $"Error handling {typeof(TRequest).Name}";
                log.Error(ex, "{ErrorMessage} RequestId: {requestId}", message, requestId);
                throw new Exception(message, ex);
            }
        }
    }
}
