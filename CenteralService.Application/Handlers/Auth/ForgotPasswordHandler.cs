using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class ForgotPasswordHandler(IAuthenticationService authenticationService) : IRequestHandler<ForgotPasswordQuery, ForgotPasswordResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ForgotPasswordAsync(request.Request);
        }
    }
}
