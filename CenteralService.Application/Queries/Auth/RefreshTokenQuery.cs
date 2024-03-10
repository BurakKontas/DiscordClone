using CenteralService.Domain;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record RefreshTokenQuery(RefreshTokenRequest Request): IRequest<LoginResponse>;
}
