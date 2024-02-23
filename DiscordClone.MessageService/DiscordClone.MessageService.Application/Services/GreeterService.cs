using DiscordClone.MessageService.Application;
using DiscordClone.MessageService.DataAccess.Contracts;
using DiscordClone.MessageService.Infrastructure;
using DiscordClone.MessageService.Service.Contracts;
using Grpc.Core;

namespace DiscordClone.MessageService.Application.Services
{
    public class GreeterService(ILogger<GreeterService> logger, IMessageService messageService) : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger = logger;
        private readonly IMessageService _messageService = messageService;

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var messages = await _messageService.GetAllMessages();
            var messageString = string.Join(", ", messages.Select(x => x.ToString()));
            return new HelloReply
            {
                Message = messageString
            };
        }
    }
}
