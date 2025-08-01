using System;

namespace SupportDeskProV2.Models
{
    public class TicketAssignment
    {
        public int TicketId { get; set; }
        public int SupportAgentId { get; set; }

        // Navigation
        public virtual Ticket Ticket { get; set; }
        public virtual User SupportAgent { get; set; }
    }
}
