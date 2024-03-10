using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class SendCustomEmailHandler(IEmailService emailService) : IRequestHandler<SendCustomEmailQuery, EmailResponse>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task<EmailResponse> Handle(SendCustomEmailQuery request, CancellationToken cancellationToken)
        {
            return await _emailService.SendCustomEmail(request.Request);
        }
    }
}
