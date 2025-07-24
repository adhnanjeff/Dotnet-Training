using System;

namespace Phase3_IssueTracker.Models
{
    public class Bug : Issue, IReportable
    {
        public string Severity { get; set; }

        public Bug(int id, string title, string assignedTo, string severity) : base(id, title, assignedTo)
        {
            if (string.IsNullOrWhiteSpace(severity))
                throw new ArgumentException("Title cannot be empty.", nameof(severity));
            Severity = severity;
        }
        // Implementing the IReportable interface method
        public void ReportStatus()
        {
            Console.WriteLine($"Bug: {Id} is under process, it is assigned To: {AssignedTo}, Severity: {Severity}");
            Status = "In Progress"; // Update status to In Progress
        }

        public void getSummary()
        {
            Console.WriteLine($"Bug Summary: ID={Id}, Title={Title}, AssignedTo={AssignedTo}, Severity={Severity}");
        }
        public override void Display()
        {
            Console.WriteLine($"Bug ID: {Id}:{Title} | Severity: {Severity}");
            Console.WriteLine($"Status: {Status}"); 
        }
    }
}