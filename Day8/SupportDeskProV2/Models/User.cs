using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual CustomerProfile? CustomerProfile { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketsNavigation { get; set; } = new List<Ticket>();
}
