

namespace BugTrackerMapper.Core.Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public required int ProjectId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
