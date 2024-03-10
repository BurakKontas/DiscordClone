using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class RefreshTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<RefreshTokenQuery, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<LoginResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RefreshTokenAsync(request.Request);
        }
    }
}
