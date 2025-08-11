namespace Hostel.Core.DTOs
{
    public class StaffRequestDTO
    {
        public string Name { get; set; }
        public List<int> RoomIds { get; set; } = new();
    }
}
