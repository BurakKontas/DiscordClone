using MessageService.Domain;
using MessageService.Service;
using MediatR;

namespace MessageService.Application.Queries
{
    public record DeleteMessageQuery(DeleteMessageRequest Request) : IRequest<DeleteMessageReply>;
}
