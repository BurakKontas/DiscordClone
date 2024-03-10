using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class ValidateTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<ValidateTokenQuery, TokenValidationResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<TokenValidationResponse> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ValidateTokenAsync(request.Request);
        }
    }
}
