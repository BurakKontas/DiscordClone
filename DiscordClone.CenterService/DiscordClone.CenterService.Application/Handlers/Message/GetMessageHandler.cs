using DiscordClone.CenterService.Application.Queries.Message;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers.Message
{
    public class GetMessageHandler(IMessageService messageService) : IRequestHandler<GetMessageQuery, GetMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessageReply> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessageAsync(request.Request);
        }
    }
}
