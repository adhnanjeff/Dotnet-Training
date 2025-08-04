using BugStatistics.Core.Interfaces;
using BugStatistics.Infrastructure.DTOs;

namespace BugStatistics.Application.Services
{
    public class BugService
    {
        private readonly IBugRepository _bugRepository;

        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public void GetAllBugs()
        {
            List<BugDTO> bugs = _bugRepository.GetAll()
                .Select(b => new BugDTO
                {
                    Title = b.Title,
                    CreatedAt = b.CreatedAt,
                    Status = b.Status,
                    Priority = b.Priority,
                    Project = b.Project.Name,
                    CreatedBy = b.CreatedBy.Username
                }).ToList();
            foreach (var bug in bugs)
            {
                Console.WriteLine($"Title: {bug.Title}, Created At: {bug.CreatedAt}, Status: {bug.Status}, Priority: {bug.Priority}, Project: {bug.Project}, Created By: {bug.CreatedBy}");
            }
        }

        
        public void FilterBugs(string? status, string? priority, string? projectName)
        {
            List<BugDTO> bugs = _bugRepository.GetAll()
                .Where(b =>
                    (string.IsNullOrEmpty(status) || b.Status.Equals(status, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(priority) || b.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(projectName) || b.Project.Name.Equals(projectName, StringComparison.OrdinalIgnoreCase)))
                .Select(b => new BugDTO
                {
                    Title = b.Title,
                    CreatedAt = b.CreatedAt,
                    Status = b.Status,
                    Priority = b.Priority,
                    Project = b.Project.Name,
                    CreatedBy = b.CreatedBy.Username
                }).ToList();

            foreach (var bug in bugs)
            {
                Console.WriteLine($"Title: {bug.Title}, Created At: {bug.CreatedAt}, Status: {bug.Status}, Priority: {bug.Priority}, Project: {bug.Project}, Created By: {bug.CreatedBy}");
            }
        }

        public void groupedStats()
        {
            List<GroupedStatsDTO> groupedStats = _bugRepository.GetAll()
                .GroupBy(b => new { b.Status, b.Priority })
                .Select(g => new GroupedStatsDTO
                {
                    Key = $"{g.Key.Status} - {g.Key.Priority}",
                    Count = g.Count()
                }).ToList();

            foreach (var group in groupedStats)
                {
                Console.WriteLine($"Key: {group.Key}, Count: {group.Count}");
            }
        }
        public void sortBugsByCreatedDate()
        {
            List<BugDTO> sortedBugs = _bugRepository.GetAll()
                .OrderBy(b => b.CreatedAt)
                .Select(b => new BugDTO
                {
                    Title = b.Title,
                    CreatedAt = b.CreatedAt,
                    Status = b.Status,
                    Priority = b.Priority,
                    Project = b.Project.Name,
                    CreatedBy = b.CreatedBy.Username
                }).ToList();

            foreach (var bug in sortedBugs)
            {
                Console.WriteLine($"Title: {bug.Title}, Created At: {bug.CreatedAt}, Status: {bug.Status}, Priority: {bug.Priority}, Project: {bug.Project}, Created By: {bug.CreatedBy}");
            }
        }
    }
}
