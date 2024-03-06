using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service.Adapters;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class ExtractTokenHandler(ITokenService tokenService) : IRequestHandler<ExtractTokenQuery, ExtractTokenResponse>
    {
        private readonly ITokenService _tokenService = tokenService;
        public Task<ExtractTokenResponse> Handle(ExtractTokenQuery request, CancellationToken cancellationToken)
        {
            var jwtToken = new JwtSecurityToken(request.request.Token);
            var details = _tokenService.ExtractToken(jwtToken);
            return Task.FromResult(details.ToExtractTokenResponse());
        }
    }
}
