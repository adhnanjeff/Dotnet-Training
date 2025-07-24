using System;
using System.Collections.Generic;
using Phase3_IssueTracker.Models;
using Phase3_IssueTracker.Services;

public class Program {
    public static void Main(string[] args){
        Phase3_IssueTracker.Models.Task task1 = new Phase3_IssueTracker.Models.Task(1, "Implement Login Feature", "Alice", 5);
        Bug bug1 = new Bug(2, "Fix Null Reference Exception", "Bob", "High");
        FeatureRequest feature1 = new FeatureRequest(3, "Add Dark Mode", "Charlie", "Dave", "2023-12-31");

        List<Issue> issues = new List<Issue>() { task1, bug1, feature1 };
        List<IReportable> reportables = new List<IReportable>() { task1, bug1, feature1 };
        TrackerService trackerService = new TrackerService();
        trackerService.DisplayAllIssues(issues);

        foreach (var issue in issues) {
            if (issue is Bug) issue.Close();
            else if(issue is FeatureRequest) issue.Close();
        }
        
        trackerService.DisplayIssueSummary(reportables);
        trackerService.ShowReportStatus(reportables);
    }
}