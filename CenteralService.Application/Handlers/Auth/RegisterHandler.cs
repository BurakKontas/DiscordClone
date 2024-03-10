using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class RegisterHandler(IAuthenticationService authenticationService) : IRequestHandler<RegisterQuery, RegisterResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<RegisterResponse> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterAsync(request.Request);
        }
    }
}
