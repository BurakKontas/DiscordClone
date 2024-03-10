using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries.Message
{
    public record GetMessagesByUserQuery(GetMessagesByUserRequest Request) : IRequest<GetMessagesByUserReply>;
}
