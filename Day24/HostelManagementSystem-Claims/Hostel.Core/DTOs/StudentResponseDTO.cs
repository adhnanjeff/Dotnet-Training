

namespace Hostel.Core.DTOs
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? RoomId { get; set; }
    }
}
