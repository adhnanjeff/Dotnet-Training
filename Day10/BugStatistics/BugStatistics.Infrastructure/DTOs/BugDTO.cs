using BugStatistics.Core.Entities;
using BugStatistics.Core.Interfaces;

namespace BugStatistics.Infrastructure.DTOs
{
    public class BugDTO
    {
        public void getAllBugs(IBugRepository _bugRepository)
        {
            var bugs = _bugRepository.GetAll();
            foreach (var bug in bugs)
            {
                Console.WriteLine($"Id: {bug.Id}, Title: {bug.Title}, Status: {bug.Status}, Priority: {bug.Priority}, Created At: {bug.CreatedAt}");
            }
        }
        public void FilterBugs(IBugRepository _bugRepository, string? status, string? priority, string? projectName)
        {
            var bugs = _bugRepository.GetAll();
            var filteredBugs = bugs.Where(b =>
                (string.IsNullOrEmpty(status) || b.Status.Equals(status, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(priority) || b.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(projectName) || b.Project.Name.Equals(projectName, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            foreach (var bug in filteredBugs)
            {
                Console.WriteLine($"Id: {bug.Id}, Title: {bug.Title}, Status: {bug.Status}, Priority: {bug.Priority}, Created At: {bug.CreatedAt}");
            }
        }

        public void sortBugsByCreatedDate(IBugRepository _bugRepository)
        {
            List<Bug> bugs = _bugRepository.GetAll();
            var sortedBugs = bugs.OrderBy(b => b.CreatedAt).ToList();
            foreach (var bug in sortedBugs)
            {
                Console.WriteLine($"Id: {bug.Id}, Title: {bug.Title}, Created At: {bug.CreatedAt}");
            }
        }
    }
}
