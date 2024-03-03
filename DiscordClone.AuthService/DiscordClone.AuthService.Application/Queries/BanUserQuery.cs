using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record BanUserQuery(BanUserRequest BanUserRequest) : IRequest<BanUserResponse>;
}
