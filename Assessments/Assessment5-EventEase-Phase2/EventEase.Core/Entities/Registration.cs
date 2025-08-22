

namespace EventEase.Core.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public required DateOnly RegDate { get; set; }
    }
}
