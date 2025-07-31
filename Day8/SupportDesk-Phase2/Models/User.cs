using System;
using System.Collections.Generic;

namespace SupportDesk_Phase2.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public virtual CustomerProfile? CustomerProfile { get; set; }
        public virtual ICollection<Ticket> TicketsRaised { get; set; } = new List<Ticket>();
        public virtual ICollection<Ticket> TicketsAssigned { get; set; } = new List<Ticket>();
    }
}