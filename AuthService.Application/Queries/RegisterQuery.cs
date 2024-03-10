using AuthService.Domain;
using AuthService.Service;
using MediatR;

namespace AuthService.Application.Queries
{
    public record RegisterQuery(RegisterRequest request) : IRequest<RegisterResponse>;
}
