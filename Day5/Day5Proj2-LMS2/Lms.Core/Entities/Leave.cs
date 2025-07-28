namespace Lms.Core.Entities
{
    public class Leave
    {
        public int Id { get; set; }
        public required string NameOfEmployee { get; set; }
        public required string TypeOfLeave { get; set; }
        public required string Status { get; set; }
      
    }
}
