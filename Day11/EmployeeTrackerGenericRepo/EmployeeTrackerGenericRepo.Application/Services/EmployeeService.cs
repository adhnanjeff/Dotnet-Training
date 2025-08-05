using EmployeeTrackerGenericRepo.Core.Entities;
using EmployeeTrackerGenericRepo.Core.Interfaces;

namespace EmployeeTrackerGenericRepo.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
        }
        public Employee? GetEmployeeById(int id)
        {
            return _employeeRepository.GetById(id);
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }
    }
}
