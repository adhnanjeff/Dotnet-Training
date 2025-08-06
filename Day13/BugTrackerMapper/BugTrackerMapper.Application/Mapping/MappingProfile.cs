using AutoMapper;
using BugTrackerMapper.Core.DTOs;
using BugTrackerMapper.Core.Entities;

namespace BugTrackerMapper.Application.Mapping
{
    // Inherit from AutoMapper.Profile to allow registration as a profile
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bug, BugRequestDTO>().ReverseMap();
            CreateMap<Bug, BugResponseDTO>();
        }
    }
}
