using System;

namespace Day2Proj2.Models;

public class BugReport : SupportTicket, IReportable
{
    public string Severity { get; set; }
    public BugReport(int id, string title, string description, string createBy, string severe) : base(id, title, description, createBy)
    {
        if (string.IsNullOrWhiteSpace(severe))
            throw new ArgumentException("Requested By cannot be empty.", nameof(severe));
        Severity = severe;
    }
    public void ReportStatus()
    {
        Console.WriteLine($"Bug Report: {Id} is under process, it is assigned to: {CreateBy}");
        Console.WriteLine($"Severity: {Severity}");
        Status = "In Progress"; // Update status to In Progress
    }
    public override void Display()
    {
        Console.WriteLine($"Bug Report ID: {Id}: {Title}");
        Console.WriteLine($"Severity: {Severity}");
        Console.WriteLine($"Created By: {CreateBy}");
        Console.WriteLine($"Status: {Status}");
    }
}