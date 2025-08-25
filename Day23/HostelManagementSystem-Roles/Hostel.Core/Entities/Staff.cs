namespace Hostel.Core.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
