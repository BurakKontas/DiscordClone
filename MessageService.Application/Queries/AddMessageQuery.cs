using MessageService.Domain;
using MessageService.Service;
using MediatR;

namespace MessageService.Application.Queries
{
    public record AddMessageQuery(AddMessageRequest Request) : IRequest<AddMessageReply>;
}
