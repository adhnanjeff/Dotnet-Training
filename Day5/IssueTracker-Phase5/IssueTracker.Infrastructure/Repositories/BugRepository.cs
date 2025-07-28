using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;

namespace IssueTracker.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs = new List<Bug>();
        public List<Bug> GetAll() => _bugs;

        public Bug GetBugById(int id) => _bugs.FirstOrDefault(b => b.Id == id);
        

        public void AddBug(Bug bug)
        {
            bug.Id = _bugs.Count > 0 ? _bugs.Max(b => b.Id) + 1 : 1;
            _bugs.Add(bug);
            Console.WriteLine($"Bug added: {bug.Title}");
        }

        public void UpdateBug(int id, string title, string status)
        {
            if (id != _bugs.Count) throw new KeyNotFoundException($"Bug with ID {id} not found.\n");
            var existingBug = _bugs.FirstOrDefault(b => b.Id == id);
            if(existingBug == null) throw new KeyNotFoundException($"Bug with ID {id} not found.\n");

            existingBug.Title = title;
            existingBug.Status = status;
            Console.WriteLine($"Bug updated: {existingBug.Title}\n");
        }
        public void DeleteBug(int id)
        {
            if (id != _bugs.Count) throw new KeyNotFoundException();
            var bug = _bugs.FirstOrDefault(b => b.Id == id);
            if (bug == null) throw new KeyNotFoundException($"Bug with ID {id} not found.\n");

            _bugs.Remove(bug);
            Console.WriteLine($"Bug deleted: {bug.Title}\n");
        }
    }
}
