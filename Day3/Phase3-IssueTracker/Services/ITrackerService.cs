using System;
using Phase3_IssueTracker.Models;
using Phase3_IssueTracker.Services;

namespace Phase3_IssueTracker {
    public interface ITrackerService {
  
        void DisplayAllIssues(List<Issue> issues);
        void DisplayIssueSummary(List<IReportable> issue);
        void ShowReportStatus(List<IReportable> issues);
        
    }
}