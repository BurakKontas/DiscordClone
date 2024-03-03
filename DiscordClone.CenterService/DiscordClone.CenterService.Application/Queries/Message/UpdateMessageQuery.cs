using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service;
using MediatR;

namespace DiscordClone.CenterService.Application.Queries.Message
{
    public record UpdateMessageQuery(UpdateMessageRequest Request) : IRequest<UpdateMessageReply>;
}
