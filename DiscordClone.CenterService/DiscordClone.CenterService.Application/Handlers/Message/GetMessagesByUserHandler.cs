using DiscordClone.CenterService.Application.Queries.Message;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers.Message
{
    public class GetMessagesByUserHandler(IMessageService messageService) : IRequestHandler<GetMessagesByUserQuery, GetMessagesByUserReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesByUserReply> Handle(GetMessagesByUserQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessagesByUserAsync(request.Request);
        }
    }
}
