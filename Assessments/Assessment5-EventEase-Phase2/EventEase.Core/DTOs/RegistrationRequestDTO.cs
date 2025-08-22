namespace EventEase.Core.DTOs
{
    public class RegistrationRequestDTO
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public required DateOnly RegDate { get; set; }
    }
}
