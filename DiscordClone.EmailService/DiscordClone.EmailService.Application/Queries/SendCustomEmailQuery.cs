using DiscordClone.EmailService.Domain;
using MediatR;

namespace DiscordClone.EmailService.Application.Queries
{
    public record SendCustomEmailQuery(CustomEmailRequest Request) : IRequest<EmailResponse>;

}
