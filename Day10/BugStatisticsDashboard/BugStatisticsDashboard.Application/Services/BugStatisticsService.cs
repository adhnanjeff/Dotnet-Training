using BugStatisticsDashboard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatisticsDashboard.Application.Services
{
    public class BugStatisticsService
    {
        private readonly IBugRepository _bugRepository;
        public BugStatisticsService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }
        
        public void showBugCountByStatus()
        {
            var bugs = _bugRepository.GetAllBugs();
            var bugCountByStatus = bugs.GroupBy(b => b.Status)
                                       .Select(g => new { Status = g.Key, Count = g.Count() })
                                       .ToList();
            foreach (var item in bugCountByStatus)
            {
                Console.WriteLine($"Status: {item.Status}, Count: {item.Count}");
            }
        }

        public void showBugCountByProjectAndPriority()
        {
            var bugs = _bugRepository.GetAllBugs();
            var bugCountByProjectAndPriority = bugs.GroupBy(b => new { b.ProjectName, b.Priority })
                                                   .Select(g => new { g.Key.ProjectName, g.Key.Priority, Count = g.Count() })
                                                   .ToList();
            foreach (var item in bugCountByProjectAndPriority)
            {
                Console.WriteLine($"Project: {item.ProjectName}, Priority: {item.Priority}, Count: {item.Count}");
            }
        }

        public void showDailyBugReport()
        {
            var bugs = _bugRepository.GetAllBugs();
            var dailyBugReport = bugs.GroupBy(b => b.CreatedAt.Date)
                                     .Select(g => new { Date = g.Key, Count = g.Count() })
                                     .ToList();
            foreach (var item in dailyBugReport)
            {
                Console.WriteLine($"Date: {item.Date.ToShortDateString()}, Count: {item.Count}");
            }
        }

        public void showTopCreators()
        {
            var bugs = _bugRepository.GetAllBugs();
            var topCreators = bugs.GroupBy(b => b.AssignedTo)
                                  .Select(g => new { Creator = g.Key, Count = g.Count() })
                                  .OrderByDescending(g => g.Count)
                                  .Take(5)
                                  .ToList();
            foreach (var item in topCreators)
            {
                Console.WriteLine($"Creator: {item.Creator}, Count: {item.Count}");
            }
        }
    }
}
