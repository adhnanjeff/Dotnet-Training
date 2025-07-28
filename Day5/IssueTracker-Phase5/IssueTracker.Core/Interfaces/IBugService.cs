using IssueTracker.Core.Entities;   
namespace IssueTracker.Core.Interfaces
{
    public interface IBugService {
        void CreateBug(string title, string description);
        List<Bug> GetAllBugs();
    }
}
