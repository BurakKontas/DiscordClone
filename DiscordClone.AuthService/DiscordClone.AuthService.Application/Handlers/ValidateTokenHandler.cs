using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Service;
using DiscordClone.AuthService.Service.Contracts;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class ValidateTokenHandler(ITokenService tokenService) : IRequestHandler<ValidateTokenQuery, TokenValidationResponse>
    {
        private readonly ITokenService _tokenService = tokenService;
        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<TokenValidationResponse> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var valid = _tokenService.ValidateToken(request.Request.Token);
            return new TokenValidationResponse
            {
                IsValid = valid
            };
        }
    }
}
