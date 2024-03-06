using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class RefreshTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<RefreshTokenQuery, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<LoginResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.LoginUser(request.request);
        }
    }
}
