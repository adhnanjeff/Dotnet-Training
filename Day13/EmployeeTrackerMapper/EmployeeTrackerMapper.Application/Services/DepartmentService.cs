using AutoMapper;
using EmployeeTrackerMapper.Core.Entities;
using EmployeeTrackerMapper.Core.DTOs;
using EmployeeTrackerMapper.Core.Interfaces;

namespace EmployeeTrackerMapper.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public void AddDepartment(DepartmentRequestDTO departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _departmentRepository.Add(department);
        }

        public void UpdateDepartment(DepartmentRequestDTO departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _departmentRepository.Update(department);
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);
        }

        public DepartmentResponseDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            return department != null ? _mapper.Map<DepartmentResponseDTO>(department) : null;
        }

        public List<DepartmentResponseDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return _mapper.Map<List<DepartmentResponseDTO>>(departments);
        }
    }
}
