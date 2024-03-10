using CenteralService.Domain;
using CenteralService.Service;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record ForgotPasswordQuery(ForgotPasswordRequest Request): IRequest<ForgotPasswordResponse>;
}
