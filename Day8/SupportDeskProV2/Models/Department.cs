using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SupportAgent> SupportAgents { get; set; } = new List<SupportAgent>();
}
