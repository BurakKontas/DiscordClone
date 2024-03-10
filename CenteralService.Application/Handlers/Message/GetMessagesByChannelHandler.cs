using CenteralService.Application.Queries.Message;
using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers.Message
{
    public class GetMessagesByChannelHandler(IMessageService messageService) : IRequestHandler<GetMessagesByChannelQuery, GetMessagesByChannelReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesByChannelReply> Handle(GetMessagesByChannelQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessagesByChannelAsync(request.Request);
        }
    }
}
