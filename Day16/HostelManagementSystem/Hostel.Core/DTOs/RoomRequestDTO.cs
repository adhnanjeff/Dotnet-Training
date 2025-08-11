namespace Hostel.Core.DTOs
{
    public class RoomRequestDTO
    {
        public int StaffId { get; set; } // Can be 0 or null if staff not assigned yet
        public List<int>? StudentIds { get; set; } // Optional student assignment
    }
}
