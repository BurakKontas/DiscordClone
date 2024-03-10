using AuthService.Domain;
using AuthService.Service;
using MediatR;

namespace AuthService.Application.Queries
{
    public record UnbanUserQuery(UnbanUserRequest request) : IRequest<UnbanUserResponse>;
}   
