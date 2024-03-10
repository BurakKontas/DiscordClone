using CenteralService.Domain;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record LoginQuery(LoginRequest Request): IRequest<LoginResponse>;
}
