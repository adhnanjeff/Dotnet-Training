using BugStatistics.Core.Entities;
using BugStatistics.Core.Interfaces;

namespace BugStatistics.Infrastructure.DTOs
{
    public class BugDTO
    {
        public required string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Status { get; set; } // e.g., Open, In Progress, Resolved, Closed
        public required string Priority { get; set; } // e.g., Low, Medium, High, Critical
        public required string Project { get; set; }
        public required string CreatedBy { get; set; }
        
    }
}
