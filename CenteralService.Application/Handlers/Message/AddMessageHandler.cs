using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using MediatR;
using CenteralService.Application.Queries.Message;
using CenteralService.Domain;

namespace CenteralService.Application.Handlers.Message
{
    public class AddMessageHandler(IMessageService messageService) : IRequestHandler<AddMessageQuery, AddMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<AddMessageReply> Handle(AddMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.AddMessageAsync(request.Request);
        }
    }
}
