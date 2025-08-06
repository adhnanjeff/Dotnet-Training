using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual SupportAgent? SupportAgent { get; set; }
}
