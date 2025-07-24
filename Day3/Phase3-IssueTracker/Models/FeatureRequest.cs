using System;
using System.Globalization;
using System.Xml.Linq;

namespace Phase3_IssueTracker.Models
{
    public class FeatureRequest : Issue, IReportable
    {
        public string RequestedBy { get; set; }
        public string Date { get; set; }
        public FeatureRequest(int id, string title, string assignedTo, string RequestedBy, string date) : base(id, title, assignedTo)
        {
            if (string.IsNullOrWhiteSpace(RequestedBy))
                throw new ArgumentException("Name cannot be empty.", nameof(RequestedBy));
            this.RequestedBy = RequestedBy;
            if (string.IsNullOrWhiteSpace(date))
                throw new ArgumentException("Date cannot be empty.", nameof(date));
            this.Date = date;
        }
        // Implementing the IReportable interface method
        public void ReportStatus()
        {
            Console.WriteLine($"Feature Request: {Id} is under process, it is assigned To: {AssignedTo}, Requested By: {RequestedBy}, Expected Release Date: {Date}");
            Status = "In Progress"; // Update status to In Progress
        }
        public void getSummary()
        {
            Console.WriteLine($"Feature Request Summary: ID={Id}, Title={Title}, AssignedTo={AssignedTo}, RequestedBy={RequestedBy}, Expected Release Date: {Date}");
        }
        public override void Display()
        {
            Console.WriteLine($"Feature Request ID: {Id}:{Title} | Requested By: {RequestedBy}, Expected Release Date: {Date}");
            Console.WriteLine($"Assigned To: {AssignedTo}");
            Console.WriteLine($"Status: {Status}");
        }
    }
}