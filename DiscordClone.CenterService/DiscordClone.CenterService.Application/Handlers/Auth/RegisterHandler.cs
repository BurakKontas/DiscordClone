using DiscordClone.CenterService.Application.Queries;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers
{
    public class RegisterHandler(IAuthenticationService authenticationService) : IRequestHandler<RegisterQuery, RegisterResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<RegisterResponse> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterAsync(request.Request);
        }
    }
}
