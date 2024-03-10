using AuthService.Application.Queries;
using AuthService.Domain;
using AuthService.Service;
using AuthService.Service.Contracts;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class UnbanUserHandler(IAuthenticationService authenticationService) : IRequestHandler<UnbanUserQuery, UnbanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<UnbanUserResponse> Handle(UnbanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.UnbanUser(request.request);
        }
    }
}
