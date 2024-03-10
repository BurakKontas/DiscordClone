using AuthService.Domain;
using AuthService.Service;
using MediatR;

namespace AuthService.Application.Queries
{
    public record LoginQuery(LoginRequest request) : IRequest<LoginResponse>;
}
