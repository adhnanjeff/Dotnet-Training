using Day2Proj1Phase2_IssueTracker.Models;
using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        List<Issue> issues = new List<Issue>();
        Bug bug1 = new Bug(1, "Login Issue", "Alice", "High");
        Day2Proj1Phase2_IssueTracker.Models.Task task1 = new Day2Proj1Phase2_IssueTracker.Models.Task(2, "Implement Feature X", "Bob", 5);
        FeatureRequest featureRequest1 = new FeatureRequest(3, "Add Dark Mode", "Charlie", "Alice", "2023-12-31");

        issues.Add(bug1);
        issues.Add(task1);
        issues.Add(featureRequest1);

        Console.WriteLine("All Issues:");
        foreach (Issue issue in issues)
        {
            issue.Display();
        }

        Console.WriteLine("\nReporting Status of Issues:");
        bug1.ReportStatus();
        task1.ReportStatus();

        Console.WriteLine("\nGetting Issues status:");
        int ip = 0, cp = 0, op = 0; // In Progress, Closed, Open
        foreach (Issue issue in issues)
        {
            if(issue.Status == "In Progress") ip += 1;
            else if(issue.Status == "closed") cp += 1;
            else if(issue.Status == "open") op += 1;
        }
        Console.WriteLine($"In Progress: {ip}, Closed: {cp}, Open: {op}");
    }
}

