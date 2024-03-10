using MessageService.Domain;
using MessageService.Service;
using MediatR;

namespace MessageService.Application.Queries
{
    public record GetMessagesByChannelAndTimeRangeQuery(GetMessagesByChannelAndTimeRangeRequest Request) : IRequest<GetMessagesByChannelAndTimeRangeReply>;
}
