using DiscordClone.CenterService.Application.Queries;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers
{
    public class BanUserHandler(IAuthenticationService authenticationService): IRequestHandler<BanUserQuery, BanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<BanUserResponse> Handle(BanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.BanUserAsync(request.BanUserRequest);
        }
    }
}
