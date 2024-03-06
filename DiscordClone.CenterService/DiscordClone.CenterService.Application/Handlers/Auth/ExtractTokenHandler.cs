using DiscordClone.CenterService.Application.Queries;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service.Contracts;
using MediatR;

namespace DiscordClone.CenterService.Application.Handlers
{
    public class ExtractTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<ExtractTokenQuery, ExtractTokenResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<ExtractTokenResponse> Handle(ExtractTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ExtractTokenAsync(request.request);
        }
    }
}
