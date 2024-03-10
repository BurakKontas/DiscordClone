using MessageService.Domain;
using MessageService.Service;
using MediatR;

namespace MessageService.Application.Queries
{
    public record GetMessageQuery(GetMessageRequest Request) : IRequest<GetMessageReply>;
}
