using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.EmailService.Domain.Models
{
    public class SendEmailAsyncParameters
    {
        public string[]? Emails { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public Attachments[] Attachments { get; set; } = [];
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
    }
}
