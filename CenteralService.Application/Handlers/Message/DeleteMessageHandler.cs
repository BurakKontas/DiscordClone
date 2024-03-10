using CenteralService.Service.Contracts;
using MediatR;
using CenteralService.Infrastructure;
using CenteralService.Application.Queries.Message;
using CenteralService.Domain;

namespace CenteralService.Application.Handlers.Message
{
    public class DeleteMessageHandler(IMessageService messageService) : IRequestHandler<DeleteMessageQuery, DeleteMessageReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<DeleteMessageReply> Handle(DeleteMessageQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.DeleteMessageAsync(request.Request);
        }
    }
}
