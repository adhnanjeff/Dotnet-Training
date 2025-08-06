
using EmployeeTrackerMapper.Core.DTOs;

namespace EmployeeTrackerMapper.Core.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(DepartmentRequestDTO departmentDto);
        void UpdateDepartment(DepartmentRequestDTO departmentDto);
        void DeleteDepartment(int id);
        DepartmentResponseDTO? GetDepartmentById(int id);
        List<DepartmentResponseDTO> GetAllDepartments();
    }
}
