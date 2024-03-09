using DiscordClone.EmailService.Domain;
using MediatR;

namespace DiscordClone.EmailService.Application.Queries
{
    public record SendResetPasswordEmailQuery(ResetPasswordEmailRequest Request) : IRequest<EmailResponse>;

}
