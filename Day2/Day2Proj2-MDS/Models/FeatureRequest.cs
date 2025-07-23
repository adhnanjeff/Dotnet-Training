using System;

namespace Day2Proj2.Models;

public class FeatureRequest : SupportTicket, IReportable
{
    public string RequestedBy { get; set; }
    public string ETA { get; set; }
    public FeatureRequest(int id, string title, string description, string createBy, string requestedBy, string date) 
        : base(id, title, description, createBy)
    {
        if (string.IsNullOrWhiteSpace(requestedBy))
            throw new ArgumentException("Requested By cannot be empty.", nameof(requestedBy));
        RequestedBy = requestedBy;
        if (string.IsNullOrWhiteSpace(date))
            throw new ArgumentException("Date cannot be empty.", nameof(date));
        ETA = date;
    }
    public void ReportStatus()
    {
        Console.WriteLine($"Feature Request: {Id} is under process, it is assigned to: {CreateBy}, Requested By: {RequestedBy}, Expected Release Date: {ETA}");
        Status = "In Progress"; // Update status to In Progress
    }
    public override void Display()
    {
        Console.WriteLine($"Feature Request ID: {Id}: {Title} | Requested By: {RequestedBy}, Expected Release Date: {ETA}");
        Console.WriteLine($"Created By: {CreateBy}");
        Console.WriteLine($"Status: {Status}");
    }
}