using AutoMapper;
using EmployeeTrackerMapper.Core.DTOs;
using EmployeeTrackerMapper.Core.Entities;

namespace EmployeeTrackerMapper.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeRequestDTO>().ReverseMap();
            CreateMap<Employee, EmployeeResponseDTO>();
            CreateMap<Department, DepartmentRequestDTO>().ReverseMap();
            CreateMap<Department, DepartmentResponseDTO>();
            CreateMap<EmployeeResponseDTO, EmployeeRequestDTO>();
        }
    }
}
