using Day2Proj1Phase1_IssueTracker.Models;
using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        List<Issue> issues = new List<Issue>();
        Bug bug1 = new Bug(1, "Login Issue", "Alice", "High");
        Day2Proj1Phase1_IssueTracker.Models.Task task1 = new Day2Proj1Phase1_IssueTracker.Models.Task(2, "Implement Feature X", "Bob", 5);

        issues.Add(bug1);
        issues.Add(task1);

        Console.WriteLine("All Issues:");
        foreach(Issue issue in issues) {
            issue.Display();
        }

        Console.WriteLine("\nReporting Status of Issues:");
        bug1.ReportStatus();
        task1.ReportStatus();
    }
}

