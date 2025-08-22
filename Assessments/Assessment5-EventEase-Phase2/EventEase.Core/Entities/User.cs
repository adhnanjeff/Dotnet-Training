

namespace EventEase.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public Event Event { get; set; } = null!;
        public int EventId { get; set; }
        public ICollection<Event> EventsParticipating { get; set; }
    }
}
