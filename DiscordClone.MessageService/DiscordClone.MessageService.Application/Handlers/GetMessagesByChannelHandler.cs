using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Domain;
using DiscordClone.MessageService.Service;
using DiscordClone.MessageService.Service.Adapters;
using DiscordClone.MessageService.Service.Contracts;
using MediatR;

namespace DiscordClone.MessageService.Application.Handlers
{
    public class GetMessagesByChannelHandler(IMessageService messageService) : IRequestHandler<GetMessagesByChannelQuery, GetMessagesByChannelReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesByChannelReply> Handle(GetMessagesByChannelQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageService.GetMessagesByChannel(Guid.Parse(request.Request.ChannelId));
            return new GetMessagesByChannelReply
            {
                Messages = { messages.ToMessageProtos() }
            };
        }
    }
}
