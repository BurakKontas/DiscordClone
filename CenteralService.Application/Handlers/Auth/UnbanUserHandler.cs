using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class UnbanUserHandler(IAuthenticationService authenticationService) : IRequestHandler<UnbanUserQuery, UnbanUserResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<UnbanUserResponse> Handle(UnbanUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.UnbanUserAsync(request.UnbanUserRequest);
        }
    }
}
