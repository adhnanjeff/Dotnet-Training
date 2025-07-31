using System;
using System.Collections.Generic;

namespace SupportDesk_Phase2.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; } = null!;
        public int? RaisedById { get; set; }
        public int? AssignedToId { get; set; }
        public virtual User? RaisedBy { get; set; }
        public virtual User? AssignedTo { get; set; }
        public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public virtual ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
    }
}