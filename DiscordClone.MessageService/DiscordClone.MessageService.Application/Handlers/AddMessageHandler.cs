using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Domain;
using DiscordClone.MessageService.Service.Adapters;
using DiscordClone.MessageService.Service.Contracts;
using MediatR;

namespace DiscordClone.MessageService.Application.Handlers
{
    public class AddMessageHandler(IMessageService messageService) : IRequestHandler<AddMessageQuery, AddMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<AddMessageReply> Handle(AddMessageQuery request, CancellationToken cancellationToken)
        {
            var message = request.Request.ToMessage();
            var reply = await _messageService.AddMessage(message);
            return new AddMessageReply
            {
                Message = reply.ToMessageProto()
            };
        }
    }
}
