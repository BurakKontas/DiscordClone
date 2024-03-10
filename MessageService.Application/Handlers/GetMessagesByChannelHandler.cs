using MessageService.Application.Queries;
using MessageService.Domain;
using MessageService.Service;
using MessageService.Service.Adapters;
using MessageService.Service.Contracts;
using MediatR;

namespace MessageService.Application.Handlers
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
