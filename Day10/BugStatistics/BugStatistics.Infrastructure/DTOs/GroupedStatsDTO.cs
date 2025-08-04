using BugStatistics.Core.Interfaces;


namespace BugStatistics.Infrastructure.DTOs
{
    public class GroupedStatsDTO
    {
        public string Key { get; set; } = string.Empty;
        public int Count { get; set; }
       
    }
}
