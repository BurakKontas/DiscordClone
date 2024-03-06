using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record BanUserQuery(BanUserRequest request) : IRequest<BanUserResponse>;
}
