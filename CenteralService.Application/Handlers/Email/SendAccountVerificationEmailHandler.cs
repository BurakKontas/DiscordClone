using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace CenteralService.Application.Handlers
{
    public class SendAccountVerificationEmailHandler(IEmailService emailService) : IRequestHandler<SendAccountVerificationEmailQuery, EmailResponse>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task<EmailResponse> Handle(SendAccountVerificationEmailQuery request, CancellationToken cancellationToken)
        {
            return await _emailService.SendVerificationEmail(request.Request);
        }
    }
}
