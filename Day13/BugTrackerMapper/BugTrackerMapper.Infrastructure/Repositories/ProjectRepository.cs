using BugTrackerMapper.Core.Entities;
using BugTrackerMapper.Core.Interfaces;


namespace BugTrackerMapper.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects = new();
        public void Add(Project entity)
        {
            entity.Id = _projects.Count > 0 ? _projects.Max(p => p.Id) + 1 : 1;
            _projects.Add(entity);
        }
        public void Update(Project entity)
        {
            var existingProject = GetById(entity.Id);
            if (existingProject != null)
            {
                existingProject.Name = entity.Name;
                existingProject.Description = entity.Description;
                existingProject.StartDate = entity.StartDate;
            }
        }
        public void Delete(int id)
        {
            var project = GetById(id);
            if (project != null)
            {
                _projects.Remove(project);
            }
        }
        public Project? GetById(int id)
        {
            return _projects.FirstOrDefault(p => p.Id == id);
        }
        public List<Project> GetAll()
        {
            return new List<Project>(_projects);
        }
    }
}
