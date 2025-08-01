using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class TicketHistory
{
    public int TicketHistoryId { get; set; }

    public int TicketId { get; set; }

    public string? Action { get; set; }

    public DateTime TimeStamp { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
