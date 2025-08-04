using BugStatisticsDashboard.Core.Entity;

namespace BugStatisticsDashboard.Core.Interfaces
{
    public interface IBugRepository
    {
        List<Bug> GetAllBugs();
        List<Bug> GetBugsById(int id);
        

    }
}
