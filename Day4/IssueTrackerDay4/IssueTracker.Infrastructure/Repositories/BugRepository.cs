using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;


namespace IssueTracker.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs = [];
        public List<Bug> GetAll() => _bugs;   // Returns all bugs directly returns without return keyword

        public Bug? GetBugById(int id) => _bugs.FirstOrDefault(b => b.Id == id); // Returns the first bug with the matching ID or null if not found

        public void AddBug(Bug bug)
        {
            bug.Id = _bugs.Count > 0 ? _bugs.Max(b => b.Id) + 1 : 1; // Assigns a new ID based on the current maximum ID
            _bugs.Add(bug);
        }

        public void UpdateBug(Bug bug)
        {
            var existingBug = _bugs.FindIndex(b => b.Id == bug.Id);
            if (existingBug != -1) _bugs[existingBug] = bug;
        }

        public void DeleteBug(int id)
        {
            var bug = GetBugById(id);
            if (bug != null)
            {
                _bugs.Remove(bug);
            }
        }
    }
}
