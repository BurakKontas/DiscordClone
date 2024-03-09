using DiscordClone.EmailService.Domain;
using MediatR;

namespace DiscordClone.EmailService.Application.Queries
{
    public record SendAccountVerificationEmailQuery(AccountVerificationEmailRequest Request) : IRequest<EmailResponse>;
}
