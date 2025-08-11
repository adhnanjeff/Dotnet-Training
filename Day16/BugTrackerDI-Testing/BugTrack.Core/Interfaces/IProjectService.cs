using BugTrack.Core.DTOs;
using BugTrack.Core.Entities;

namespace BugTrack.Core.Interfaces
{
    public interface IProjectService
    {
        ProjectResponseDTO CreateProject(ProjectRequestDTO pro);
        ProjectResponseDTO GetProjectById(int id);
        List<ProjectResponseDTO> GetAllProjects();
    }
}
