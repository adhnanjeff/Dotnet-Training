using BugTrack.Core.DTOs;
using BugTrack.Core.Entities;
using BugTrack.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BugTrack.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private static int _projectId = 1;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository; // ✅ Fixed assignment
        }

        public ProjectResponseDTO CreateProject(ProjectRequestDTO projectRequestDTO)
        {
            var projects = _projectRepository.GetAll();
            int nextId = projects.Any() ? projects.Max(p => p.Id) + 1 : 1;

            var newPro = new Project
            {
                Id = nextId,
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

        public void UpdateProject(int id, ProjectRequestDTO pro)
        {
            var proj = _projectRepository.GetById(id);
            _projectRepository.Update(new Project
            {
                Id = _projectId++,
                Name = pro.Name,
                Description = pro.Description
            });
        }

        public void DeleteProject(int projectId)
        {
            _projectRepository.Delete(projectId);
        }
    }
}
