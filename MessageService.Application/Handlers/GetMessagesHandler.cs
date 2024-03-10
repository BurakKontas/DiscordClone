using MessageService.Application.Queries;
using MessageService.Domain;
using MessageService.Service;
using MessageService.Service.Adapters;
using MessageService.Service.Contracts;
using MediatR;

namespace MessageService.Application.Handlers
{
    public class GetMessagesHandler(IMessageService messageService) : IRequestHandler<GetMessagesQuery, GetMessagesReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesReply> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageService.GetAllMessages();
            return new GetMessagesReply
            {
                Messages = { messages.ToMessageProtos() }
            };
        }
    }
}
