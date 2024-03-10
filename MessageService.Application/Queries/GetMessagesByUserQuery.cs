using MessageService.Domain;
using MessageService.Service;
using MediatR;

namespace MessageService.Application.Queries
{
    public record GetMessagesByUserQuery(GetMessagesByUserRequest Request) : IRequest<GetMessagesByUserReply>;
}
