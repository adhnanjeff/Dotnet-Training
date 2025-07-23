using System;

namespace Day2Proj1Phase1_IssueTracker.Models
{
    public class Bug : Issue, IReportable
    {
        public string Severity { get; set; }
        
        public Bug (int id, string title, string assignedTo, string severity) : base(id, title, assignedTo) {
            Severity = severity;
        }
        // Implementing the IReportable interface method
        public void ReportStatus() {
            Console.WriteLine($"Bug: {Id} is under process, it is assigned To: {AssignedTo}, Severity: {Severity}");
        }
        public override void Display() {
            Console.WriteLine($"Bug ID: {Id}:{Title} | Severity: {Severity}");
        }
    }
}