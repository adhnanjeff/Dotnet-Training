using BugTrack.Core.DTOs;
using BugTrack.Core.Entities;

namespace BugTrack.Core.Interfaces
{
    public interface IProjectService
    {
        ProjectResponseDTO CreateProject(ProjectRequestDTO pro);
        ProjectResponseDTO GetProjectById(int id);
        List<ProjectResponseDTO> GetAllProjects();
        void UpdateProject(int id, ProjectRequestDTO pro);
        void DeleteProject(int id);
    }
}
