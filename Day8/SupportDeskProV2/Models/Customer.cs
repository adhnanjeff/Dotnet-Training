using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class Customer
{
    public int Id { get; set; }

    public virtual CustomerProfile? CustomerProfile { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
