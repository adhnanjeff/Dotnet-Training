using System;
using System.Collections.Generic;

namespace Assessment2_BugTrackerLite.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;

    public string TicketDesc { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly? CreatedDate { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public virtual ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();

}
