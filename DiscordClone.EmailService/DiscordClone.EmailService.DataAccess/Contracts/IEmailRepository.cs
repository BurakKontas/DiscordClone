using DiscordClone.EmailService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.EmailService.DataAccess.Contracts
{
    public interface IEmailRepository
    {
        Task<Task> SendEmailAsync(string to, string subject, string body);
        Task<Task> SendEmailAsync(string to, string subject, string body, Attachments[] attachments);
        Task<Task> SendEmailAsync(string[] to, string subject, string body);
        Task<Task> SendEmailAsync(string[] to, string subject, string body, Attachments[] attachments);
        Task<Task> SendEmailAsync(string[] to, string subject, string body, Attachments[] attachments, string senderName, string senderEmail);
        Task<Task> SendEmailAsync(string to, string subject, string body, string senderName, string senderEmail);
        Task<Task> SendEmailAsync(string to, string subject, string body, Attachments[] attachments, string senderName, string senderEmail);
        Task<Task> SendEmailAsync(string[] to, string subject, string body, string senderName, string senderEmail);
    }
}
