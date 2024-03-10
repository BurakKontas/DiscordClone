using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class BanUserHandler(IAuthenticationService authenticationService): IRequestHandler<BanUserQuery, BanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<BanUserResponse> Handle(BanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.BanUserAsync(request.BanUserRequest);
        }
    }
}
