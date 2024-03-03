using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record RefreshTokenQuery(RefreshTokenRequest Request): IRequest<TokenResponse>;
}
