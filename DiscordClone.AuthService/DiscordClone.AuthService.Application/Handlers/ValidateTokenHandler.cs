using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class ValidateTokenHandler(): IRequestHandler<ValidateTokenQuery, TokenValidationResponse>
    {
        public async Task<TokenValidationResponse> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
