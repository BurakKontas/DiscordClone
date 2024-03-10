using CenteralService.Application.Queries;
using CenteralService.Domain;
using Grpc.Core;
using MediatR;

namespace CenteralService.Application.Controllers.gRPC
{
    public class EmailProtoController(IMediator mediator): EmailProtoService.EmailProtoServiceBase
    {
        private readonly IMediator _mediator = mediator;
        public async override Task<EmailResponse> SendAccountVerificationEmail(AccountVerificationEmailRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new SendAccountVerificationEmailQuery(request));
        }

        public async override Task<EmailResponse> SendCustomEmail(CustomEmailRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new SendCustomEmailQuery(request));
        }

        public async override Task<EmailResponse> SendResetPasswordEmail(ResetPasswordEmailRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new SendResetPasswordEmailQuery(request));
        }
    }
}
