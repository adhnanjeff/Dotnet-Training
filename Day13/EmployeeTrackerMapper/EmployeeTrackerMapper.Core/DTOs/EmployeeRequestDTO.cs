

namespace EmployeeTrackerMapper.Core.DTOs
{
    public class EmployeeRequestDTO
    {
        public required string Name { get; set; }
        public required string Role { get; set; } 
        public int Salary { get; set; }
        public int DepartmentId { get; set; }

    }
}
