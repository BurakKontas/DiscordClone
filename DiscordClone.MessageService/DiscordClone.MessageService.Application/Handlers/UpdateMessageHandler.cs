using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Domain;
using DiscordClone.MessageService.Service;
using DiscordClone.MessageService.Service.Adapters;
using DiscordClone.MessageService.Service.Contracts;
using Grpc.Core;
using MediatR;

namespace DiscordClone.MessageService.Application.Handlers
{
    public class UpdateMessageHandler(IMessageService messageService) : IRequestHandler<UpdateMessageQuery, UpdateMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<UpdateMessageReply> Handle(UpdateMessageQuery request, CancellationToken cancellationToken)
        {
            var message = request.Request.ToMessage();
            var updatedMessage = await _messageService.UpdateMessage(message) ?? throw new RpcException(new Status(StatusCode.NotFound, $"Message with ID {message.MessageId} not found."));
            return new UpdateMessageReply
            {
                Message = updatedMessage.ToMessageProto()
            };
        }
    }
}
