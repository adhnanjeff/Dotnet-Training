using BugTrack.Core.Entities;
using BugTrack.Core.Interfaces;

namespace BugTrack.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs = new();
        public void Add(Bug entity)
        {
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
                existingBug.ProjectId = entity.ProjectId;
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
        public Bug GetById(int id)
        {
            return _bugs.FirstOrDefault(b => b.Id == id);
        }
        public List<Bug> GetAll()
        {
            return _bugs;
        }
        public void SaveChanges()
        {
            // In a real application, this would save changes to the database.
            // Here, we are just simulating the save operation.
        }
        
    }
}
