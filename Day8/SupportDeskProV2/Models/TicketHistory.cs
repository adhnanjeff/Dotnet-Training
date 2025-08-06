using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class TicketHistory
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public string? ActionTaken { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
