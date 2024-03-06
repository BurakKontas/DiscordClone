using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record ForgotPasswordQuery(ForgotPasswordRequest request) : IRequest<ForgotPasswordResponse>;
}
