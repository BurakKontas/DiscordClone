using MessageService.Domain;
using MessageService.Service;
using MediatR;

namespace MessageService.Application.Queries
{
    public record GetMessagesByChannelQuery(GetMessagesByChannelRequest Request) : IRequest<GetMessagesByChannelReply>;
}
