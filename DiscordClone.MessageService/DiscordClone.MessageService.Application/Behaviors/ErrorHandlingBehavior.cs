using DiscordClone.MessageService.Domain.Models;
using Grpc.Core;
using MediatR;

namespace DiscordClone.MessageService.Application.Behaviors
{
    public class ErrorHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await next();
                return response;
            }
            catch (Exception ex)
            {
                var message = $"Error handling {typeof(TRequest).Name} \nStackTrace: {ex.StackTrace}\n Message: {ex.Message}";
                throw new RpcException(new Status(StatusCode.Internal, message, ex));
            }
        }
    }
}
