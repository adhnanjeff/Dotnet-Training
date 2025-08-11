using BugTrack.Core.DTOs;


namespace BugTrack.Core.Interfaces
{
    public interface IBugService
    {
        void AddBug(BugRequestDTO bugRequest);
        void UpdateBug(int id, BugRequestDTO bugRequest);
        void DeleteBug(int id);
        BugRequestDTO GetBugById(int id);
        List<BugResponseDTO> GetAllBugs();
        List<BugResponseDTO> GetBugsByProjectId(int projectId);
        // List<BugRequestDTO> GetBugsByStatus(string status);
    }
}
