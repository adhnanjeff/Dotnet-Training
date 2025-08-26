namespace Hostel.MVC.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public List<string> StudentNames { get; set; }
    }
}
