using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries.Message
{
    public record GetMessagesByChannelQuery(GetMessagesByChannelRequest Request) : IRequest<GetMessagesByChannelReply>;
}
