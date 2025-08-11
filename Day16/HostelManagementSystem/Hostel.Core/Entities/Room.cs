namespace Hostel.Core.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; } = null!;
        public List<Student> Students { get; set; } = new();
    }
}
