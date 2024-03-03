using DiscordClone.MessageService.Domain;
using DiscordClone.MessageService.Service;
using MediatR;

namespace DiscordClone.MessageService.Application.Queries
{
    public record GetMessageQuery(GetMessageRequest Request) : IRequest<GetMessageReply>;
}
