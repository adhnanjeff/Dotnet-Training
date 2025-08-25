namespace Hostel.MVC.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? RoomId { get; set; }
    }
}
