using Grpc.Core.Interceptors;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.LoadBalancer.Infrastructure.Interceptors
{
    public class LoggingInterceptor(MessageContext messageContext) : Interceptor
    {
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var requestId = Guid.NewGuid().ToString();
            messageContext.LogRequest(requestId, $"Starting call. Type/Method: {context.Method.Type} / {context.Method.Name}");
            var call = continuation(request, context);
            return  new AsyncUnaryCall<TResponse>(
                HandleResponse(requestId!, call.ResponseAsync),
                call.ResponseHeadersAsync,
                call.GetStatus,
                call.GetTrailers,
                call.Dispose);

        }

        private async Task<TResponse> HandleResponse<TResponse>(string requestId, Task<TResponse> inner)
        {
            try
            {
                var response = await inner;
                messageContext.LogResponse(requestId, $"Response: {response}");
                return response;
            }
            catch (Exception ex)
            {
                messageContext.LogError(requestId, ex);
                throw new InvalidOperationException($"An error occurred while processing the request with ({requestId}) GUID: {ex.Message}", ex);
            }
        }
    }
}
