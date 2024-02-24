using DiscordClone.CenterService.Application.Queries.Message;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers.Message
{
    public class GetMessagesHandler(IMessageService messageService) : IRequestHandler<GetMessagesQuery, GetMessagesReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesReply> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessagesAsync(request.Request);
        }
    }
}
