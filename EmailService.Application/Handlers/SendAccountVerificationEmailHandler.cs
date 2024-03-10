using EmailService.Application.Queries;
using EmailService.Domain;
using EmailService.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace EmailService.Application.Handlers
{
    public class SendAccountVerificationEmailHandler(IEmailService emailService) : IRequestHandler<SendAccountVerificationEmailQuery, EmailResponse>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task<EmailResponse> Handle(SendAccountVerificationEmailQuery request, CancellationToken cancellationToken)
        {
            var response = await _emailService.SendConfirmationEmailAsync(request.Request);
            if (response.IsCompleted)
            {
                return new EmailResponse { Success = true , Message = "Email Send Successfully"};
            }
            else
            {
                return new EmailResponse { Success = false, Message = "Email Send Failed"};
            }
        }
    }
}
