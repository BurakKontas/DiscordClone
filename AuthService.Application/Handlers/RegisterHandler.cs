using AuthService.Application.Queries;
using AuthService.Domain;
using AuthService.Service;
using AuthService.Service.Contracts;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class RegisterHandler(IAuthenticationService authenticationService) : IRequestHandler<RegisterQuery, RegisterResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<RegisterResponse> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterUser(request.request);
        }
    }
}
