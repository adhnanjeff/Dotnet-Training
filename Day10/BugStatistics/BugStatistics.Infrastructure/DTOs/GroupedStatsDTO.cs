using BugStatistics.Core.Interfaces;


namespace BugStatistics.Infrastructure.DTOs
{
    public class GroupedStatsDTO
    {
        public string Key { get; set; } = string.Empty;
        public int Count { get; set; }
        //public void groupedStats(IBugRepository _bugRepository)
        //{
        //    Console.WriteLine("Grouped stats feature is not yet implemented.");
        //    var bugs = _bugRepository.GetAll();
        //    var groupedStats = bugs.GroupBy(b => new { b.Status, b.Priority })
        //                           .Select(g => new
        //                           {
        //                               Status = g.Key.Status,
        //                               Priority = g.Key.Priority,
        //                               Count = g.Count(),
        //                               CreatedAt = g.Min(b => b.CreatedAt)
        //                           })
        //                           .ToList();
        //    foreach (var group in groupedStats)
        //    {
        //        Console.WriteLine($"Status: {group.Status}, Priority: {group.Priority}, Count: {group.Count}, Earliest Created At: {group.CreatedAt}");
        //    }
        //}
    }
}
