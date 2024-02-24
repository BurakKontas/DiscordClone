using DiscordClone.CenterService.Service.Contracts;
using MediatR;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Application.Queries.Message;

namespace DiscordClone.CenterService.Application.Handlers.Message
{
    public class DeleteMessageHandler(IMessageService messageService) : IRequestHandler<DeleteMessageQuery, DeleteMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<DeleteMessageReply> Handle(DeleteMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.DeleteMessageAsync(request.Request);
        }
    }
}
