
using BugTrack.Core.DTOs;
using BugTrack.Core.Entities;


namespace BugTrack.Core.Interfaces
{
    public interface IProjectRepository 
    {
        void Create(Project pro);
        Project GetById(int id);
        List<Project> GetAll();
    }
}
