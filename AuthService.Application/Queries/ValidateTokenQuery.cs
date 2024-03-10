using AuthService.Domain;
using AuthService.Service;
using MediatR;

namespace AuthService.Application.Queries
{
    public record ValidateTokenQuery(TokenValidationRequest request) : IRequest<TokenValidationResponse>;
}
