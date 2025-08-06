using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class SupportAgent
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<TicketSupportAgent> TicketSupportAgents { get; set; } = new List<TicketSupportAgent>();

}
