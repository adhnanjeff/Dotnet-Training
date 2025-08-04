using BugStatistics.Core.Entities;

namespace BugStatistics.Core.Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Status { get; set; } // e.g., Open, In Progress, Resolved, Closed
        public required string Priority { get; set; } // e.g., Low, Medium, High, Critical
        public required Project Project { get; set; }
        public required User CreatedBy { get; set; }

    }
}
