using System;
using System.Collections.Generic;

namespace SupportDesk.Core.Entities;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;
    //public string Status { get; set; } = "Open";
    //public int Priority { get; set; } = 1;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public virtual ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();

}
