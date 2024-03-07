using System;
using System.Collections.Generic;

namespace DiscordClone.AuthService.Domain.Models;

public partial class Auth
{
    public int Id { get; set; }

    public Guid Useruuid { get; set; }
    public string? Username { get; set; }

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public bool? EmailVerified { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool? Banned { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Ban> Bans { get; set; } = new List<Ban>();

    public virtual Role? Role { get; set; }
}
