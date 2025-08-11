using BugTrack.Core.DTOs;
using BugTrack.Core.Entities;
using BugTrack.Core.Interfaces;

namespace BugTrack.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private int _projectId = 1;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository; // ✅ Fixed assignment
        }

        public ProjectResponseDTO CreateProject(ProjectRequestDTO projectRequestDTO)
        {
            var newPro = new Project
            {
                Id = _projectId++,
                Name = projectRequestDTO.Name,
                Description = projectRequestDTO.Description,
            };
            _projectRepository.Create(newPro);
            return new ProjectResponseDTO
            {
                Id = newPro.Id,
                Name = newPro.Name,
                Description = newPro.Description
            };
        }


        public ProjectResponseDTO GetProjectById(int id)
        {
            var pro = _projectRepository.GetById(id);
            if (pro == null) return null;

            return new ProjectResponseDTO
            {
                Id = pro.Id,
                Name = pro.Name,
                Description = pro.Description,
            };
        }

        public List<ProjectResponseDTO> GetAllProjects()
        {
            var pros = _projectRepository.GetAll();
            if (pros == null || !pros.Any()) return new List<ProjectResponseDTO>();

            return pros.Select(b => new ProjectResponseDTO
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description
            }).ToList();
        }
    }
}
