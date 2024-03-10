using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries.Message
{
    public record GetMessagesQuery(GetMessagesRequest Request) : IRequest<GetMessagesReply>;
}
