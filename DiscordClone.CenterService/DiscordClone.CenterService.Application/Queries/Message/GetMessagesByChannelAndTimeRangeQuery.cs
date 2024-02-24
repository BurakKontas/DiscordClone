using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service;
using MediatR;

namespace DiscordClone.CenterService.Application.Queries.Message
{
    public record GetMessagesByChannelAndTimeRangeQuery(GetMessagesByChannelAndTimeRangeRequest Request) : IRequest<GetMessagesByChannelAndTimeRangeReply>;
}
