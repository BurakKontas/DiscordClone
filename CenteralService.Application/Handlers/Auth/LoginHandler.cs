using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class LoginHandler(IAuthenticationService authenticationService) : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.LoginAsync(request.Request);
        }
    }
}
