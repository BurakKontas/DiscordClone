using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class RegisterHandler(IAuthenticationService authenticationService) : IRequestHandler<RegisterQuery, RegisterResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<RegisterResponse> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterUser(request.request);
        }
    }
}
