using DiscordClone.MessageService.Service;
using MediatR;

namespace DiscordClone.MessageService.Application.Queries
{
    public record GetMessagesQuery(GetMessagesRequest Request) : IRequest<GetMessagesReply>;
}
