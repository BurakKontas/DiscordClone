using MessageService.Application.Queries;
using MessageService.Domain;
using MessageService.Service;
using MessageService.Service.Adapters;
using MessageService.Service.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessageService.Application.Handlers
{
    public class GetMessagesByChannelAndTimeRangeHandler(IMessageService messageService) : IRequestHandler<GetMessagesByChannelAndTimeRangeQuery, GetMessagesByChannelAndTimeRangeReply>
    {
        private readonly IMessageService _messageService = messageService;

        public async Task<GetMessagesByChannelAndTimeRangeReply> Handle(GetMessagesByChannelAndTimeRangeQuery request, CancellationToken cancellationToken)
        {

            if (!DateTime.TryParse(request.Request.StartTime, out DateTime startTime) || !DateTime.TryParse(request.Request.EndTime, out DateTime endTime))
                throw new ArgumentException("Invalid date format");

            var messages = await _messageService.GetMessagesByChannelAndTimeRange(Guid.Parse(request.Request.ChannelId), startTime, endTime);
            return new GetMessagesByChannelAndTimeRangeReply
            {
                Messages = { messages.ToMessageProtos() }
            };
        }
    }
}
