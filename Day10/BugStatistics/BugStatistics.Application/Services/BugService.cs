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
            BugDTO bugDTO = new BugDTO();
            bugDTO.getAllBugs(_bugRepository);
        }

        
        public void FilterBugs(string? status, string? priority, string? projectName)
        {
            BugDTO bugDTO = new BugDTO();
            bugDTO.FilterBugs(_bugRepository, status, priority, projectName);
        }

        public void groupedStats()
        {
            GroupedStatsDTO groupedStatsDTO = new GroupedStatsDTO();
            groupedStatsDTO.groupedStats(_bugRepository);
        }
        public void sortBugsByCreatedDate()
        {
            BugDTO bugDTO = new BugDTO();
            bugDTO.sortBugsByCreatedDate(_bugRepository);
        }
    }
}
