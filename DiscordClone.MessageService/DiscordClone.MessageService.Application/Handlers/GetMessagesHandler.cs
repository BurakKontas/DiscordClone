using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Service;
using DiscordClone.MessageService.Service.Adapters;
using DiscordClone.MessageService.Service.Contracts;
using MediatR;

namespace DiscordClone.MessageService.Application.Handlers
{
    public class GetMessagesHandler(IMessageService messageService) : IRequestHandler<GetMessagesQuery, GetMessagesReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesReply> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageService.GetAllMessages();
            return new GetMessagesReply
            {
                Messages = { messages.ToMessageProtos() }
            };
        }
    }
}
