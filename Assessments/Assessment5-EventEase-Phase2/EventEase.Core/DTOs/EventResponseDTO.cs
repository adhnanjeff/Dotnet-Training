

using EventEase.Core.Entities;

namespace EventEase.Core.DTOs
{
    public class EventResponseDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Desc { get; set; }
        public required DateOnly EventDate { get; set; }
        public required string Location { get; set; }
        public List<string> Participants { get; set; } = new();
    }
}
