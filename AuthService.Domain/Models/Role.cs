using System;
using System.Collections.Generic;

namespace AuthService.Domain.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Auth> Auths { get; set; } = new List<Auth>();
}
