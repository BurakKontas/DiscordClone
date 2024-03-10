using AuthService.Domain;
using MediatR;

namespace AuthService.Application.Queries
{
    public record ExtractTokenQuery(ExtractTokenRequest request) : IRequest<ExtractTokenResponse>;

}
