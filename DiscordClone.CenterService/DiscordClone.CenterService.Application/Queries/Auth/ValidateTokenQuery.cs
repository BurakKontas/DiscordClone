using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using MediatR;

namespace DiscordClone.CenterService.Application.Queries
{
    public record ValidateTokenQuery(TokenValidationRequest Request): IRequest<TokenValidationResponse>;
}
