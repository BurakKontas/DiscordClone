using AuthService.Application.Queries;
using AuthService.Domain;
using AuthService.Service;
using AuthService.Service.Contracts;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class ForgotPasswordHandler(IAuthenticationService authenticationService) : IRequestHandler<ForgotPasswordQuery, ForgotPasswordResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ForgotPassword(request.request);
        }
    }
}
