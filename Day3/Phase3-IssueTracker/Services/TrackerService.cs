using Phase3_IssueTracker.Models;
using System;

namespace Phase3_IssueTracker.Services
{
    public class TrackerService : ITrackerService {
        public TrackerService() { }
        public void DisplayAllIssues(List<Issue> issues) {
            Console.WriteLine("Displaying all issues...");
            foreach (var issue in issues) {
                issue.Display();
                Console.WriteLine();
            }
        }
        public void DisplayIssueSummary(List<IReportable> issue) {
            if (issue == null || issue.Count == 0) {
                Console.WriteLine("No issue to display.");
                return;
            }
            Console.WriteLine("Displaying issue summary...");
            foreach (var item in issue) {
                item.getSummary();
                Console.WriteLine();
            }
        }

        public void ShowReportStatus(List<IReportable> issue) {
            if(issue == null || issue.Count == 0) Console.WriteLine("No issues or bugs to report");
            else {
                Console.WriteLine("Reporting status of issues...");
                foreach (var item in issue) {
                    item.ReportStatus();
                    Console.WriteLine();
                }
            }
        }
    }
}