using EmailService.DataAccess.Contracts;
using EmailService.Domain.Models;
using EmailService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.DataAccess.Repositories
{
    public class EmailRepository(EmailContext context) : IEmailRepository
    {
        private readonly EmailContext _context = context;
        public Task<Task> SendEmailAsync(string to, string subject, string body)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = [to],
                Subject = subject,
                Body = body
            };
            return _context.SendEmailAsync(parameters);
        }

        public Task<Task> SendEmailAsync(string to, string subject, string body, Attachments[] attachments)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = [to],
                Subject = subject,
                Body = body,
                Attachments = attachments
            };
            return _context.SendEmailAsync(parameters);
        }

        public Task<Task> SendEmailAsync(string[] to, string subject, string body)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = to,
                Subject = subject,
                Body = body
            };
            return _context.SendEmailAsync(parameters);
        }

        public Task<Task> SendEmailAsync(string[] to, string subject, string body, Attachments[] attachments)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = to,
                Subject = subject,
                Body = body,
                Attachments = attachments
            };
            return _context.SendEmailAsync(parameters);
        }

        public Task<Task> SendEmailAsync(string[] to, string subject, string body, Attachments[] attachments, string senderName, string senderEmail)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = to,
                Subject = subject,
                Body = body,
                Attachments = attachments,
                SenderName = senderName,
                SenderEmail = senderEmail
            };
            return _context.SendEmailAsync(parameters);
        }

        public Task<Task> SendEmailAsync(string to, string subject, string body, string senderName, string senderEmail)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = [to],
                Subject = subject,
                Body = body,
                SenderName = senderName,
                SenderEmail = senderEmail
            };
            return _context.SendEmailAsync(parameters);
        }

        public Task<Task> SendEmailAsync(string to, string subject, string body, Attachments[] attachments, string senderName, string senderEmail)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = [to],
                Subject = subject,
                Body = body,
                Attachments = attachments,
                SenderName = senderName,
                SenderEmail = senderEmail
            };
            return _context.SendEmailAsync(parameters);
        }

        public Task<Task> SendEmailAsync(string[] to, string subject, string body, string senderName, string senderEmail)
        {
            var parameters = new SendEmailAsyncParameters
            {
                Emails = to,
                Subject = subject,
                Body = body,
                SenderName = senderName,
                SenderEmail = senderEmail
            };
            return _context.SendEmailAsync(parameters);
        }
    }
}
