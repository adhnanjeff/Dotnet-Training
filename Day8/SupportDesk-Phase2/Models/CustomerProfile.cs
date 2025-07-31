using System;

namespace SupportDesk_Phase2.Models
{
    public partial class CustomerProfile
    {
        public int UserId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public virtual User? User { get; set; }
    }
}