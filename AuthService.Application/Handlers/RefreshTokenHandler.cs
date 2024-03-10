using AuthService.Application.Queries;
using AuthService.Domain;
using AuthService.Service;
using AuthService.Service.Contracts;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class RefreshTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<RefreshTokenQuery, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<LoginResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.LoginUser(request.request);
        }
    }
}
