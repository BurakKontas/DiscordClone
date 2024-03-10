using CenteralService.Domain;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record BanUserQuery(BanUserRequest BanUserRequest) : IRequest<BanUserResponse>;
}
