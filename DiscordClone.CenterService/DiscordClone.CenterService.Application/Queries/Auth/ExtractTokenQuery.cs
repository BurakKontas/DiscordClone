using DiscordClone.CenterService.Domain;
using MediatR;

namespace DiscordClone.CenterService.Application.Queries
{
    public record ExtractTokenQuery(ExtractTokenRequest request) : IRequest<ExtractTokenResponse>;

}
