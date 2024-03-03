using DiscordClone.CenterService.Application.Queries.Message;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers.Message
{
    public class UpdateMessageHandler(IMessageService messageService) : IRequestHandler<UpdateMessageQuery, UpdateMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<UpdateMessageReply> Handle(UpdateMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.UpdateMessageAsync(request.Request);
        }
    }
}
