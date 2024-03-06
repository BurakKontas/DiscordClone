using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class LoginHandler(IAuthenticationService authenticationService) : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.LoginUser(request.request, null);
        }
    }
}
