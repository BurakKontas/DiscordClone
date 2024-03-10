using EmailService.Domain;
using MediatR;

namespace EmailService.Application.Queries
{
    public record SendCustomEmailQuery(CustomEmailRequest Request) : IRequest<EmailResponse>;

}
