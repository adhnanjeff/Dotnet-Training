

namespace EventEase.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateOnly EventDate { get; set; }
        public required string Location { get; set; }

    }
}
