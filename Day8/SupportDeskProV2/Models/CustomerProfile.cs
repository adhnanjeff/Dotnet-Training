using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class CustomerProfile
{
    public int UserId { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual User User { get; set; } = null!;
}
