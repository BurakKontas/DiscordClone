using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class BanUserHandler(IAuthenticationService authenticationService): IRequestHandler<BanUserQuery, BanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<BanUserResponse> Handle(BanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.BanUser(request.request);
        }
    }
}
