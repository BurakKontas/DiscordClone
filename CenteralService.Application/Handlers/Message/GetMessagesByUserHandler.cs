using CenteralService.Application.Queries.Message;
using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers.Message
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
