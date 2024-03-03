using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Domain;
using DiscordClone.MessageService.Service.Adapters;
using DiscordClone.MessageService.Service.Contracts;
using MediatR;

namespace DiscordClone.MessageService.Application.Handlers
{
    public class GetMessageHandler(IMessageService messageService) : IRequestHandler<GetMessageQuery, GetMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessageReply> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageService.GetMessage(Guid.Parse(request.Request.MessageId));
            return new GetMessageReply
            {
                Message = message.ToMessageProtos()
            };
        }
    }
}
