using System;
using System.Collections.Generic;

namespace AuthService.Domain.Models;

public partial class Ban
{
    public int Id { get; set; }

    public Guid Useruuid { get; set; }

    public Guid Adminuuid { get; set; }

    public string BanReason { get; set; } = null!;

    public DateTime BanDate { get; set; }

    public virtual Auth User { get; set; } = null!;
}
