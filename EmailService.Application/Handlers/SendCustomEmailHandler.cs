using EmailService.Application.Queries;
using EmailService.Domain;
using EmailService.Service.Contracts;
using MediatR;

namespace EmailService.Application.Handlers
{
    public class SendCustomEmailHandler(IEmailService emailService) : IRequestHandler<SendCustomEmailQuery, EmailResponse>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task<EmailResponse> Handle(SendCustomEmailQuery request, CancellationToken cancellationToken)
        {
            var response = await _emailService.SendCustomEmailAsync(request.Request);
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
