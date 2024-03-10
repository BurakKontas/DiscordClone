using AuthService.Domain;
using AuthService.Service;
using MediatR;

namespace AuthService.Application.Queries
{
    public record RefreshTokenQuery(RefreshTokenRequest request) : IRequest<LoginResponse>;
}
