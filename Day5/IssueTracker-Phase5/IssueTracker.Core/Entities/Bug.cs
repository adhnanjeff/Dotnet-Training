namespace IssueTracker.Core.Entities
{
    public class Bug {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; } // e.g., Open, In Progress, Closed
    }
}
