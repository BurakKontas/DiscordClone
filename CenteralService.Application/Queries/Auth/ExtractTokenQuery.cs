using CenteralService.Domain;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record ExtractTokenQuery(ExtractTokenRequest request) : IRequest<ExtractTokenResponse>;

}
