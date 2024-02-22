using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using DiscordClone.LoadBalander.Infrastructure;
using Grpc.Core.Interceptors;
using DiscordClone.LoadBalancer.Infrastructure.Interceptors;
using Serilog;



namespace DiscordClone.LoadBalancer.Infrastructure
{
    public class MessageContext
    {
        public Greeter.GreeterClient Client { get; set; }
        private readonly ILogger _logger;


        public MessageContext(ILogger logger)
        {
            _logger = logger.ForContext<MessageContext>();
            var channel = GrpcChannel.ForAddress("http://172.23.32.1:32775/");
            var invoker = channel
                .Intercept(new LoggingInterceptor(this));
            Client = new Greeter.GreeterClient(invoker);
        }

        public void LogRequest(string requestId, string request)
        {
            _logger
                .ForContext("RequestId", requestId)
                .ForContext("Request", request)
                .Debug($"{requestId} {request}");
        }

        public void LogResponse(string requestId, string response)
        {
            _logger
                .ForContext("RequestId", requestId)
                .ForContext("Response", response)
                .Debug($"{requestId} {response}");
        }

        public void LogError(string requestId, Exception ex)
        {
            _logger
                .ForContext("RequestId", requestId)
                .ForContext("Exception", ex)
                .Error(ex, $"{requestId} {ex.Message}");
        }

    }
}
