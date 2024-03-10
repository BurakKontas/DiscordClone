using AuthService.Application.Queries;
using AuthService.Domain;
using AuthService.Service.Adapters;
using AuthService.Service.Contracts;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace AuthService.Application.Handlers
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
