using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class ForgotPasswordHandler(IAuthenticationService authenticationService) : IRequestHandler<ForgotPasswordQuery, ForgotPasswordResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ForgotPassword(request.Request);
        }
    }
}
