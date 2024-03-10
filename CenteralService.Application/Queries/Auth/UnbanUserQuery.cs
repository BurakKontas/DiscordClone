using CenteralService.Domain;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record UnbanUserQuery(UnbanUserRequest UnbanUserRequest) : IRequest<UnbanUserResponse>;
}   
