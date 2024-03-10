using CenteralService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenteralService.Service.Contracts
{
    public interface IEmailService
    {
        Task<EmailResponse> SendResetPasswordEmail(ResetPasswordEmailRequest request);
        Task<EmailResponse> SendVerificationEmail(AccountVerificationEmailRequest request);
        Task<EmailResponse> SendCustomEmail(CustomEmailRequest request);
    }
}
