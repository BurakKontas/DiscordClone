using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;
using DiscordClone.CenterService.Application.Queries.Message;

namespace DiscordClone.CenterService.Application.Handlers.Message
{
    public class AddMessageHandler(IMessageService messageService) : IRequestHandler<AddMessageQuery, AddMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<AddMessageReply> Handle(AddMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.AddMessageAsync(request.Request);
        }
    }
}
