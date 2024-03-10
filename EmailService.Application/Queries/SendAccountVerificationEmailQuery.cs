using EmailService.Domain;
using MediatR;

namespace EmailService.Application.Queries
{
    public record SendAccountVerificationEmailQuery(AccountVerificationEmailRequest Request) : IRequest<EmailResponse>;
}
