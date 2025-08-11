using BugTrack.Core.Entities;
using BugTrack.Core.Interfaces;

namespace BugTrack.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _repository = new();

        public Project GetById(int id)
        {
            return _repository.FirstOrDefault(b => b.Id == id);
        }

        public List<Project> GetAll()
        {
            return _repository;
        }

        public void Create(Project pro)
        {
            _repository.Add(pro);
        }
    }
}
