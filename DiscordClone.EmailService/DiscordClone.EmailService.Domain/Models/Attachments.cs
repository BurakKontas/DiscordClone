using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.EmailService.Domain.Models
{
    public class Attachments
    {
        public string? FileName { get; set; }
        public byte[]? File { get; set; }
    }
}
