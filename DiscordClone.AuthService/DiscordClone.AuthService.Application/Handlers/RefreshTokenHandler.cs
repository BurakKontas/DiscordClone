using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class RefreshTokenHandler(): IRequestHandler<RefreshTokenQuery, TokenResponse>
    {
        public async Task<TokenResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
