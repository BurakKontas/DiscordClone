using CenteralService.Application.Queries;
using CenteralService.Domain;
using CenteralService.Service.Contracts;
using MediatR;

namespace CenteralService.Application.Handlers
{
    public class SendResetPasswordEmailHandler(IEmailService emailService): IRequestHandler<SendResetPasswordEmailQuery, EmailResponse>
    {
        private readonly IEmailService _emailService = emailService;
        public async Task<EmailResponse> Handle(SendResetPasswordEmailQuery request, CancellationToken cancellationToken)
        {
            return await _emailService.SendResetPasswordEmail(request.Request);
        }
    }
}
