using MessageService.Domain;
using MessageService.Service;
using MediatR;

namespace MessageService.Application.Queries
{
    public record GetMessagesQuery(GetMessagesRequest Request) : IRequest<GetMessagesReply>;
}
