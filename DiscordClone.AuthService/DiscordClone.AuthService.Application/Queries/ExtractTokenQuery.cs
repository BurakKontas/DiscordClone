using DiscordClone.AuthService.Domain;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record ExtractTokenQuery(ExtractTokenRequest request) : IRequest<ExtractTokenResponse>;

}
