public class RoomResponseDTO
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public string StaffName { get; set; }
    public List<int> StudentIds { get; set; } = new List<int>();
}
