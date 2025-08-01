using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Core.Entities
{
    public class TicketTag
    {
        public int TicketId { get; set; }
        public int TagId { get; set; }
        public required Ticket Ticket { get; set; }
        public required Tag Tag { get; set; }
    }
}
