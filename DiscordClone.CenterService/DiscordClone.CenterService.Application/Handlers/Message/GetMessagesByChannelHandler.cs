using DiscordClone.CenterService.Application.Queries.Message;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers.Message
{
    public class GetMessagesByChannelHandler(IMessageService messageService) : IRequestHandler<GetMessagesByChannelQuery, GetMessagesByChannelReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesByChannelReply> Handle(GetMessagesByChannelQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessagesByChannelAsync(request.Request);
        }
    }
}
