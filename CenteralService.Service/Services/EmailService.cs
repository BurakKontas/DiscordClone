using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenteralService.Service.Services
{
    public class EmailService(EmailContext context) : IEmailService
    {
        private readonly EmailContext _context = context;

        public async Task<EmailResponse> SendCustomEmail(CustomEmailRequest request)
        {
            return await _context.Client.SendCustomEmailAsync(request);
        }

        public async Task<EmailResponse> SendResetPasswordEmail(ResetPasswordEmailRequest request)
        {
            return await _context.Client.SendResetPasswordEmailAsync(request);
        }

        public async Task<EmailResponse> SendVerificationEmail(AccountVerificationEmailRequest request)
        {
            return await _context.Client.SendAccountVerificationEmailAsync(request);
        }
    }
}
