using DiscordClone.CenterService.Application.Queries;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers
{
    public class ForgotPasswordHandler(IAuthenticationService authenticationService) : IRequestHandler<ForgotPasswordQuery, ForgotPasswordResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ForgotPasswordAsync(request.Request);
        }
    }
}
