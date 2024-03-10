using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class ExtractTokenHandler(IAuthenticationService authenticationService) : IRequestHandler<ExtractTokenQuery, ExtractTokenResponse>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<ExtractTokenResponse> Handle(ExtractTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.ExtractTokenAsync(request.request);
        }
    }
}
