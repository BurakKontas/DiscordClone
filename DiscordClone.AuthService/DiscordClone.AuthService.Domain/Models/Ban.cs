using System;
using System.Collections.Generic;

namespace DiscordClone.AuthService.Domain.Models;

public partial class Ban
{
    public int Id { get; set; }

    public Guid Useruuid { get; set; }

    public Guid Adminuuid { get; set; }

    public string BanReason { get; set; } = null!;

    public DateTime BanDate { get; set; }

    public virtual Auth Useruu { get; set; } = null!;
}
