using AuthService.Application.Queries;
using AuthService.Domain;
using AuthService.Service;
using AuthService.Service.Contracts;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class BanUserHandler(IAuthenticationService authenticationService): IRequestHandler<BanUserQuery, BanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<BanUserResponse> Handle(BanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.BanUser(request.request);
        }
    }
}
