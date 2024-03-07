using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.AuthService.Domain.Models
{
    public class TokenDetails
    {
        public string? Username { get; set; }
        public int? RoleId { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public Guid? Useruuid { get; set; }
    }
}
