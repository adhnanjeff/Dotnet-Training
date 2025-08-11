

namespace Hostel.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? RoomId { get; set; } 
        public Room? Room { get; set; }
    }
}
