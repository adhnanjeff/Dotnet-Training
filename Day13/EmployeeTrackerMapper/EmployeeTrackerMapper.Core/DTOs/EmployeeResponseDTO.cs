

namespace EmployeeTrackerMapper.Core.DTOs
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
        public int DepartmentId { get; set; }
    }
}
