

using EventEase.Core.Entities;

namespace EventEase.Core.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public List<string> Events { get; set; } = new();
    }
}
