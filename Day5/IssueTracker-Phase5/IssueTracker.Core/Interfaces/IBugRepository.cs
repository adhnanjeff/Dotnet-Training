using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Interfaces
{
    public interface IBugRepository
    {
        List<Bug> GetAll();
        Bug GetBugById(int id);
        void AddBug(Bug bug);
        void UpdateBug(int id, string title, string status);
        void DeleteBug(int id);

    }
}
