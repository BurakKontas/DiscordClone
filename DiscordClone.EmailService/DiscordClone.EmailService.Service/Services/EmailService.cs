using System.Threading.Tasks;
using DiscordClone.EmailService.DataAccess.Contracts;
using DiscordClone.EmailService.Domain;
using DiscordClone.EmailService.Domain.Models;
using DiscordClone.EmailService.Service.Contracts;

namespace DiscordClone.EmailService.Services
{
    public class EmailService(IEmailRepository emailRepository) : IEmailService
    {
        private readonly IEmailRepository _emailRepository = emailRepository;

        public async Task<Task> SendConfirmationEmailAsync(AccountVerificationEmailRequest request)
        {
            var template = new HTMLTemplate("ConfimAccountTemplate");
            template.ChangeValue("USERNAME", request.Username);
            template.ChangeValue("CONFIRMATION_LINK", $"http://localhost:8080/"+request.Token);
            var result = await _emailRepository.SendEmailAsync(request.Email, "Confirm your account", template.HTML);
            return result;
        }
        public async Task<Task> SendPasswordResetEmailAsync(ResetPasswordEmailRequest request)
        {
            var template = new HTMLTemplate("ResetPasswordTemplate");
            template.ChangeValue("USERNAME", request.Username);
            template.ChangeValue("RESET_PASSWORD_LINK", $"http://localhost:8080/"+request.Token);
            return await _emailRepository.SendEmailAsync(request.Email, "Reset your password", template.HTML);
        }
        public async Task<Task> SendCustomEmailAsync(CustomEmailRequest request)
        {
            var list = request.Email.ToArray();
            return await _emailRepository.SendEmailAsync(list, request.Subject, request.Body);
        }
    }
}
