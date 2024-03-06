using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using MediatR;

namespace DiscordClone.CenterService.Application.Queries
{
    public record BanUserQuery(BanUserRequest BanUserRequest) : IRequest<BanUserResponse>;
}
