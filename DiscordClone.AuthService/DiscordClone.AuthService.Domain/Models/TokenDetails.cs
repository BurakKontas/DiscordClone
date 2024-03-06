using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.AuthService.Domain.Models
{
    public class TokenDetails
    {
        public int? Role { get; set; }
        public string? RoleName { get; set; }
        public string? Email { get; set; }
        public Guid Useruuid { get; set; }
    }
}
