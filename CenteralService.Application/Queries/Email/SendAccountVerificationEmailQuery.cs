using CenteralService.Domain;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record SendAccountVerificationEmailQuery(AccountVerificationEmailRequest Request) : IRequest<EmailResponse>;
}
