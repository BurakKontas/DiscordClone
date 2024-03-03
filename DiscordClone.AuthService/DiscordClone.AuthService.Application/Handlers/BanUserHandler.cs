using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class BanUserHandler(): IRequestHandler<BanUserQuery, BanUserResponse>
    {
        public async Task<BanUserResponse> Handle(BanUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    {
    }
}
