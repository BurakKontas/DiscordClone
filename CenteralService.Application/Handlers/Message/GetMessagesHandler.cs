using CenteralService.Application.Queries.Message;
using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers.Message
{
    public class GetMessagesHandler(IMessageService messageService) : IRequestHandler<GetMessagesQuery, GetMessagesReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesReply> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessagesAsync(request.Request);
        }
    }
}
