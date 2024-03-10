using MessageService.Application.Queries;
using MessageService.Domain;
using MessageService.Service.Adapters;
using MessageService.Service.Contracts;
using MediatR;

namespace MessageService.Application.Handlers
{
    public class AddMessageHandler(IMessageService messageService) : IRequestHandler<AddMessageQuery, AddMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<AddMessageReply> Handle(AddMessageQuery request, CancellationToken cancellationToken)
        {
            var message = request.Request.ToMessage();
            var reply = await _messageService.AddMessage(message);
            return new AddMessageReply
            {
                Message = reply.ToMessageProto()
            };
        }
    }
}
