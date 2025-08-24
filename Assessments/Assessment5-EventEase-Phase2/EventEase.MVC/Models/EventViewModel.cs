
namespace EventEase.MVC.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Desc { get; set; }
        public required DateOnly EventDate { get; set; }
        public required string Location { get; set; }
        public List<string> Participants { get; set; } = new();
    }
}
