
namespace EmployeeTrackerMapper.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
        public required int Salary { get; set; }
        public required int DepartmentId { get; set; }
    }
}
