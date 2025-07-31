using System;
using System.Collections.Generic;

namespace SupportDesk_Phase2.Models
{
    public partial class TicketHistory
    {
        public int HistoryId { get; set; }
        public int? TicketId { get; set; }
        public string TicketDesc { get; set; } = null!;
        public DateTime? TimeStamp { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}