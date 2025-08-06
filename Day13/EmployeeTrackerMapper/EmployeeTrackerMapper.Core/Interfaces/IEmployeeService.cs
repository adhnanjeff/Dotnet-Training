
using EmployeeTrackerMapper.Core.DTOs;

namespace EmployeeTrackerMapper.Core.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeRequestDTO employeeDto);
        void UpdateEmployee(EmployeeRequestDTO employeeDto);
        void DeleteEmployee(int id);
        EmployeeResponseDTO? GetEmployeeById(int id);
        List<EmployeeResponseDTO> GetAllEmployees();
    }
}
