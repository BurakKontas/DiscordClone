using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class RegisterHandler() : IRequestHandler<RegisterQuery, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
