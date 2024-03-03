using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record GenerateTokenQuery(TokenRequest Request): IRequest<TokenResponse>;
}
