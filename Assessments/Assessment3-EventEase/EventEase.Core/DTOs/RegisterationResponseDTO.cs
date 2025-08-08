using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.DTOs
{
    public class RegisterationResponseDTO
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateOnly DateTime { get; set; }
    }
}
