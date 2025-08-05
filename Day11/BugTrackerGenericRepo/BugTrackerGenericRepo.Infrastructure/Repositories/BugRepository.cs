using BugTrackerGenericRepo.Core.Interfaces;
using BugTrackerGenericRepo.Core.Entities;

namespace BugTrackerGenericRepo.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs = new();
        public void Add(Bug entity)
        {
            entity.Id = _bugs.Count > 0 ? _bugs.Max(b => b.Id) + 1 : 1;
            _bugs.Add(entity);
        }
        public void Update(Bug entity)
        {
            var existingBug = GetById(entity.Id);
            if (existingBug != null)
            {
                existingBug.Title = entity.Title;
                existingBug.Description = entity.Description;
                existingBug.Status = entity.Status;
                existingBug.AssignedTo = entity.AssignedTo;
                existingBug.Priority = entity.Priority;
            }
        }
        public void Delete(int id)
        {
            var bug = GetById(id);
            if (bug != null)
            {
                _bugs.Remove(bug);
            }
        }
        public Bug? GetById(int id)
        {
            return _bugs.FirstOrDefault(b => b.Id == id);
        }
        public List<Bug> GetAll()
        {
            return new List<Bug>(_bugs);
        }
    }
}
