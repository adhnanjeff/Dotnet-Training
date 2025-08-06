using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;

namespace BugTrackerGenericRepo.Infrastructure.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly List<Project> _projects = new();
        public void Add(Project entity)
        {
            entity.Id = _projects.Count > 0 ? _projects.Max(p => p.Id) + 1 : 1;
            _projects.Add(entity);
        }
        public void Remove(Project entity)
        {
            var existingProject = GetById(entity.Id);
            if (existingProject != null)
            {
                _projects.Remove(existingProject);
            }
        }
        public void Update(Project entity)
        {
            var existingProject = GetById(entity.Id);
            if (existingProject != null)
            {
                existingProject.Name = entity.Name;
                existingProject.StartDate = entity.StartDate;
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
