using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class UnbanUserHandler(IAuthenticationService authenticationService) : IRequestHandler<UnbanUserQuery, UnbanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<UnbanUserResponse> Handle(UnbanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.UnbanUser(request.request);
        }
    }
}
