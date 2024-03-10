using CenteralService.Domain;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record RegisterQuery(RegisterRequest Request): IRequest<RegisterResponse>;
}
