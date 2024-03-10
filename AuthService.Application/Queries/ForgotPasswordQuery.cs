using AuthService.Domain;
using AuthService.Service;
using MediatR;

namespace AuthService.Application.Queries
{
    public record ForgotPasswordQuery(ForgotPasswordRequest request) : IRequest<ForgotPasswordResponse>;
}
