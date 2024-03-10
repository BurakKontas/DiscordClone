using MessageService.Application.Queries;
using MessageService.Domain;
using MessageService.Service.Adapters;
using MessageService.Service.Contracts;
using MediatR;

namespace MessageService.Application.Handlers
{
    public class GetMessageHandler(IMessageService messageService) : IRequestHandler<GetMessageQuery, GetMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessageReply> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageService.GetMessage(Guid.Parse(request.Request.MessageId));
            return new GetMessageReply
            {
                Message = message.ToMessageProto()
            };
        }
    }
}
