using BugStatistics.Core.Entities;
using BugStatistics.Core.Interfaces;

namespace BugStatistics.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs;

        public BugRepository(Project pro, User user)
        {
            _bugs = new List<Bug>
            {
                new Bug { Id = 1, Title = "Bug 1", Project = pro, Status = "Closed", CreatedAt = DateTime.Now.AddDays(-4), Priority = "Medium", CreatedBy = user },
                new Bug { Id = 2, Title = "Bug 2", Project = pro, Status = "Open", CreatedAt = DateTime.Now.AddDays(-2), Priority = "High", CreatedBy = user },
                new Bug { Id = 3, Title = "Bug 3", Project = pro, Status = "In Progress", CreatedAt = DateTime.Now.AddDays(-1), Priority = "Low", CreatedBy = user },
                new Bug { Id = 4, Title = "Bug 4", Project = pro, Status = "Resolved", CreatedAt = DateTime.Now.AddDays(-3), Priority = "Critical", CreatedBy = user },
                new Bug { Id = 5, Title = "Bug 5", Project = pro, Status = "Open", CreatedAt = DateTime.Now.AddDays(-5), Priority = "Medium", CreatedBy = user }
            };
        }
        public List<Bug> GetAll() => _bugs;
        public List<Bug> GetBugsById(int id) => _bugs.Where(b => b.Id == id).ToList();
    }
}
