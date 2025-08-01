using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Status { get; set; } = null!;

    public int CustomerId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User Customer { get; set; } = null!;

    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
    public virtual ICollection<TicketAssignment> TicketAssignment { get; set; } = new List<TicketAssignment>();

    public virtual ICollection<User> SupportAgents { get; set; } = new List<User>();
}
