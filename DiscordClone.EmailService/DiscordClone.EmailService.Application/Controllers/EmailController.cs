using DiscordClone.EmailService.Application.Queries;
using DiscordClone.EmailService.Domain;
using DiscordClone.EmailService.Service.Contracts;
using Grpc.Core;
using MediatR;

namespace DiscordClone.EmailService.Application.Controllers
{
    public class EmailController(IMediator mediator) : EmailProtoService.EmailProtoServiceBase
    {
        private readonly IMediator _mediator = mediator;
        public async override Task<EmailResponse> SendResetPasswordEmail(ResetPasswordEmailRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new SendResetPasswordEmailQuery(request));
        }

        public async override Task<EmailResponse> SendAccountVerificationEmail(AccountVerificationEmailRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new SendAccountVerificationEmailQuery(request));
        }

        public async override Task<EmailResponse> SendCustomEmail(CustomEmailRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new SendCustomEmailQuery(request));
        }
    }
}
