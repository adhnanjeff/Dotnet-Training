using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Core.DTOs
{
    public class BugRequestDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int ProjectId { get; set; }
        // public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Open"; 
    }
}
