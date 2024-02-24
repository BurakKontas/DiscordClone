using DiscordClone.MessageService.Service;
using MediatR;

namespace DiscordClone.MessageService.Application.Queries
{
    public record GetMessagesByChannelQuery(GetMessagesByChannelRequest Request) : IRequest<GetMessagesByChannelReply>;
}
