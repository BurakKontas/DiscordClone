using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class UnbanUserHandler(): IRequestHandler<UnbanUserQuery, UnbanUserResponse>
    {
        public async Task<UnbanUserResponse> Handle(UnbanUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
