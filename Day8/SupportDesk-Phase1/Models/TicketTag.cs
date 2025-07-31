using System;

namespace SupportDesk_Phase1.Models
{
	public class TicketTag
	{
		public int TicketId { get; set; }
		public int TagId { get; set; }
		public Ticket Ticket { get; set; }
		public Tag Tag { get; set; }
	}
}