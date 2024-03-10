using EmailService.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Infrastructure
{
    public class EmailContext
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly IConfigurationSection _mailSettings;

        public EmailContext(IConfiguration configuration)
        {
            _configuration = configuration;

            _mailSettings = _configuration.GetSection("MailSettings");
            _smtpClient = new(_mailSettings["Server"], int.Parse(_mailSettings["Port"]!))
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailSettings["UserName"], _mailSettings["Password"])
            };
        }

        public async Task<Task> SendEmailAsync(SendEmailAsyncParameters parameters)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress($"{_mailSettings["SenderName"]} <{_mailSettings["SenderEmail"]}>"),
                Subject = parameters.Subject,
                Body = parameters.Body,
                IsBodyHtml = true
            };

            foreach (var email in parameters.Emails!)
            {
                mailMessage.To.Add(email);
            }

            foreach (var attachment in parameters.Attachments!)
            {
                mailMessage.Attachments.Add(new Attachment(new MemoryStream(attachment.File!), attachment.FileName));
            }

            await _smtpClient.SendMailAsync(mailMessage);
            return Task.CompletedTask;
        }
    }
}
