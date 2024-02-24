using DiscordClone.MessageService.Service;
using MediatR;

namespace DiscordClone.MessageService.Application.Queries
{
    public record GetMessagesByChannelAndTimeRangeQuery(GetMessagesByChannelAndTimeRangeRequest Request) : IRequest<GetMessagesByChannelAndTimeRangeReply>;
}
