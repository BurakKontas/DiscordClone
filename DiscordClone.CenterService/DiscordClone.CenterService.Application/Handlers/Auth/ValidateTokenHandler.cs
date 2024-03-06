using DiscordClone.CenterService.Application.Queries;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers
{
    public class ValidateTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<ValidateTokenQuery, TokenValidationResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<TokenValidationResponse> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ValidateTokenAsync(request.Request);
        }
    }
}
