using CenteralService.Domain;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record ValidateTokenQuery(TokenValidationRequest Request): IRequest<TokenValidationResponse>;
}
