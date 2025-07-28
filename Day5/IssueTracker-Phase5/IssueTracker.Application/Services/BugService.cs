using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;

namespace IssueTracker.Application.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _repo;
        public BugService(IBugRepository repo)
        {
            _repo = repo;
        }

        public void CreateBug(string title, string description)
        {
            var bug = new Bug
            {
                Title = title,
                Description = description,
                Status = "Open"
            };
            _repo.AddBug(bug);
            Console.WriteLine($"Bug created: {bug.Title}\n");
        }

        public List<Bug> GetAllBugs()
        {
            Console.WriteLine("Trying to fetch all bugs...\n");
            return _repo.GetAll();
        }
    }
}
