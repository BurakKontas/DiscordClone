using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Handlers
{
    public class ForgotPasswordHandler(): IRequestHandler<ForgotPasswordQuery, ForgotPasswordResponse>
    {
        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
