using System;

namespace Assessment2_BugTrackerLite.Models
{
    public class TicketTag
    {
        public int TicketId { get; set; }
        public int TagId { get; set; }
        public Ticket Ticket { get; set; }
        public Tag Tag { get; set; }
    }
}