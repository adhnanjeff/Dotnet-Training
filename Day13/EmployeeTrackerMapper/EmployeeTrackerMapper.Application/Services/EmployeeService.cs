using AutoMapper;
using EmployeeTrackerMapper.Core.Entities;
using EmployeeTrackerMapper.Core.DTOs;
using EmployeeTrackerMapper.Core.Interfaces;

namespace EmployeeTrackerMapper.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public void AddEmployee(EmployeeRequestDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Add(employee);
        }
        public void UpdateEmployee(EmployeeRequestDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Update(employee);
        }
        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
        }
        public EmployeeResponseDTO? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee != null ? _mapper.Map<EmployeeResponseDTO>(employee) : null;
        }
        public List<EmployeeResponseDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return _mapper.Map<List<EmployeeResponseDTO>>(employees);
        }
    }
}
