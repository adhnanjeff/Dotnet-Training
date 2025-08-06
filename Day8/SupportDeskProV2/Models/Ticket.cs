using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Status { get; set; }

    public int CustomerId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();

    public virtual ICollection<SupportAgent> SupportAgents { get; set; } = new List<SupportAgent>();
    public virtual ICollection<TicketSupportAgent> TicketSupportAgents { get; set; } = new List<TicketSupportAgent>();

}
