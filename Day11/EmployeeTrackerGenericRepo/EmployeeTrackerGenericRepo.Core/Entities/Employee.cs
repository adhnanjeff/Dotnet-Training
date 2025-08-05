

namespace EmployeeTrackerGenericRepo.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string EmpName { get; set; } 
        public required Department Department { get; set; } = new Department();
        public required int DepartmentId { get; set; }
        public required int Salary { get; set; }

    }
}
