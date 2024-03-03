using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Domain;
using DiscordClone.MessageService.Service;
using DiscordClone.MessageService.Service.Adapters;
using DiscordClone.MessageService.Service.Contracts;
using MediatR;

namespace DiscordClone.MessageService.Application.Handlers
{
    public class GetMessagesByUserHandler(IMessageService messageService) : IRequestHandler<GetMessagesByUserQuery, GetMessagesByUserReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesByUserReply> Handle(GetMessagesByUserQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageService.GetMessagesByUser(Guid.Parse(request.Request.UserId));
            return new GetMessagesByUserReply
            {
                Messages = { messages.ToMessageProtos() }
            };
        }
    }
}
