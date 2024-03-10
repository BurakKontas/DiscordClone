using CenteralService.Application.Queries.Message;
using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers.Message
{
    public class UpdateMessageHandler(IMessageService messageService) : IRequestHandler<UpdateMessageQuery, UpdateMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<UpdateMessageReply> Handle(UpdateMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.UpdateMessageAsync(request.Request);
        }
    }
}
