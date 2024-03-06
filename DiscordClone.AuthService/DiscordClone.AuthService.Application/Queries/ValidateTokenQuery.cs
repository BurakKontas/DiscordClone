using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record ValidateTokenQuery(TokenValidationRequest Request): IRequest<TokenValidationResponse>;
}
