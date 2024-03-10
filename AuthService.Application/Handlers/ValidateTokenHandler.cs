using AuthService.Application.Queries;
using AuthService.Domain;
using AuthService.Service;
using AuthService.Service.Contracts;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class ValidateTokenHandler(ITokenService tokenService) : IRequestHandler<ValidateTokenQuery, TokenValidationResponse>
    {
        private readonly ITokenService _tokenService = tokenService;
        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<TokenValidationResponse> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var valid = _tokenService.ValidateToken(request.request.Token);
            return new TokenValidationResponse
            {
                IsValid = valid
            };
        }
    }
}
