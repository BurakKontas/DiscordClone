using CenteralService.Application.Queries.Message;
using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CenteralService.Application.Handlers.Message
{
    public class GetMessagesByChannelAndTimeRangeHandler(IMessageService messageService) : IRequestHandler<GetMessagesByChannelAndTimeRangeQuery, GetMessagesByChannelAndTimeRangeReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesByChannelAndTimeRangeReply> Handle(GetMessagesByChannelAndTimeRangeQuery request, CancellationToken cancellationToken)
        {
            return await _messageService.GetMessagesByDateAsync(request.Request);
        }
    }
}
