using DiscordClone.CenterService.Application.Queries;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers
{
    public class UnbanUserHandler(IAuthenticationService authenticationService) : IRequestHandler<UnbanUserQuery, UnbanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<UnbanUserResponse> Handle(UnbanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.UnbanUserAsync(request.UnbanUserRequest);
        }
    }
}
