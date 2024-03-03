using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class GenerateTokenHandler(): IRequestHandler<GenerateTokenQuery, TokenResponse>
    {
        public async Task<TokenResponse> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
