using EmailService.Domain;
using MediatR;

namespace EmailService.Application.Queries
{
    public record SendResetPasswordEmailQuery(ResetPasswordEmailRequest Request) : IRequest<EmailResponse>;

}
