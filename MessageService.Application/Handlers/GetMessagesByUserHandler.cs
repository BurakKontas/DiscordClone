using MessageService.Application.Queries;
using MessageService.Domain;
using MessageService.Service;
using MessageService.Service.Adapters;
using MessageService.Service.Contracts;
using MediatR;

namespace MessageService.Application.Handlers
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
