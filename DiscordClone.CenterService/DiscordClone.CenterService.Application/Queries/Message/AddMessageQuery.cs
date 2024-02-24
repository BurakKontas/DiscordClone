using DiscordClone.CenterService.Infrastructure;
using MediatR;

namespace DiscordClone.CenterService.Application.Queries.Message
{
    public record AddMessageQuery(AddMessageRequest Request) : IRequest<AddMessageReply>;
}
