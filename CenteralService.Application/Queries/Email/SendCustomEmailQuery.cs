using CenteralService.Domain;
using MediatR;

namespace CenteralService.Application.Queries
{
    public record SendCustomEmailQuery(CustomEmailRequest Request) : IRequest<EmailResponse>;

}
