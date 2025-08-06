using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;
// using BugTrackerGenericRepo.Infrastructure.Repositories;

namespace BugTrackerGenericRepo.Application.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void CreateProject(Project project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            _projectRepository.Add(project);
        }
        public void UpdateProject(Project project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            _projectRepository.Update(project);
        }
        public void DeleteProject(int id)
        {
            _projectRepository.Delete(id);
        }
        public Project? GetProjectById(int id)
        {
            return _projectRepository.GetById(id);
        }
        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }
    }
}
