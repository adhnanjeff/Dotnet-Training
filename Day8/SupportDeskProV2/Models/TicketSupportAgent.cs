using System;

namespace SupportDeskProV2.Models
{
    public partial class TicketSupportAgent
    {
        public int TicketId { get; set; }
        public int SupportAgentId { get; set; }

        public virtual Ticket Ticket { get; set; } = null!;
        public virtual SupportAgent SupportAgent { get; set; } = null!;
    }
}
