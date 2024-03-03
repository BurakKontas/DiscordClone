using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Domain;
using DiscordClone.MessageService.Service;
using DiscordClone.MessageService.Service.Contracts;
using MediatR;

namespace DiscordClone.MessageService.Application.Handlers
{
    public class DeleteMessageHandler(IMessageService messageService) : IRequestHandler<DeleteMessageQuery, DeleteMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<DeleteMessageReply> Handle(DeleteMessageQuery request, CancellationToken cancellationToken)
        {
            var message = Guid.Parse(request.Request.MessageId);
            var reply = await _messageService.DeleteMessage(message);
            return new DeleteMessageReply
            {
                IsSuccess = reply,
                MessageId = request.Request.MessageId
            };
        }
    }
}
