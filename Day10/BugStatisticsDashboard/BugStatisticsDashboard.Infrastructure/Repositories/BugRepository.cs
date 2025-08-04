using BugStatisticsDashboard.Core.Interfaces;
using BugStatisticsDashboard.Core.Entity;

namespace BugStatisticsDashboard.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs;

        public BugRepository()
        {
            _bugs = new List<Bug>
            {
                new Bug { Id = 1, Title = "Bug 1", ProjectName = "Project A", Status = "Open", CreatedAt = DateTime.Now, Priority = "High", AssignedTo = "User1" },
                new Bug { Id = 2, Title = "Bug 2", ProjectName = "Project B", Status = "Closed", CreatedAt = DateTime.Now.AddDays(-1), Priority = "Medium", AssignedTo = "User2" },
                new Bug { Id = 3, Title = "Bug 3", ProjectName = "Project A", Status = "In Progress", CreatedAt = DateTime.Now.AddDays(-2), Priority = "Low", AssignedTo = "User3" },
                new Bug { Id = 4, Title = "Bug 4", ProjectName = "Project C", Status = "Open", CreatedAt = DateTime.Now.AddDays(-3), Priority = "High", AssignedTo = "User1" },
                new Bug { Id = 5, Title = "Bug 5", ProjectName = "Project B", Status = "Closed", CreatedAt = DateTime.Now.AddDays(-4), Priority = "Medium", AssignedTo = "User2" }
            };
        }
        public List<Bug> GetAllBugs() => _bugs;
        public List<Bug> GetBugsById(int id) => _bugs.Where(b => b.Id == id).ToList();
    }
}
