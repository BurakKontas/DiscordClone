using CenteralService.Domain;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record SendResetPasswordEmailQuery(ResetPasswordEmailRequest Request) : IRequest<EmailResponse>;

}
