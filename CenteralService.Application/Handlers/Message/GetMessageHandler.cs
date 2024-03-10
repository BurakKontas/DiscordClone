using CenteralService.Application.Queries.Message;
using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers.Message
{
    public class GetMessageHandler(IMessageService messageService) : IRequestHandler<GetMessageQuery, GetMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessageReply> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessageAsync(request.Request);
        }
    }
}
