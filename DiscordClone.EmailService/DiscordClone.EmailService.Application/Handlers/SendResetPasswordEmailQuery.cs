using DiscordClone.EmailService.Application.Queries;
using DiscordClone.EmailService.Domain;
using DiscordClone.EmailService.Service.Contracts;
using MediatR;

namespace DiscordClone.EmailService.Application.Handlers
{
    public class SendResetPasswordEmailHandler(IEmailService emailService): IRequestHandler<SendResetPasswordEmailQuery, EmailResponse>
    {
        private readonly IEmailService _emailService = emailService;
        public async Task<EmailResponse> Handle(SendResetPasswordEmailQuery request, CancellationToken cancellationToken)
        {
            var response = await _emailService.SendPasswordResetEmailAsync(request.Request);
            if (response.IsCompleted)
            {
                return new EmailResponse { Success = true, Message = "Email Send Successfully" };
            }
            else
            {
                return new EmailResponse { Success = false, Message = "Email Send Failed" };
            }
        }
    }
}
