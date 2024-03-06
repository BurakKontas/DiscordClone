using DiscordClone.CenterService.Application.Queries;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers
{
    public class RefreshTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<RefreshTokenQuery, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<LoginResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RefreshTokenAsync(request.Request);
        }
    }
}
