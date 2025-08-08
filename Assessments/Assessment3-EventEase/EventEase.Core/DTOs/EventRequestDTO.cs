

namespace EventEase.Core.DTOs
{
    public class EventRequestDTO
    {
        public required string Title { get; set; }
        public required string Desc { get; set; }
        public required DateOnly EventDate { get; set; }
        public required string Location { get; set; }
    }
}
