using System;
namespace Day2Proj1Phase1_IssueTracker.Models
{
    public class Task : Issue, IReportable
    {
        public int estimatedHours { get; set; }
        public Task(int id, string title, string assignedTo, int estimatedHours) : base(id, title, assignedTo)
        {
            this.estimatedHours = estimatedHours;
        }
        // Implementing the IReportable interface method
        public void ReportStatus()
        {
            Console.WriteLine($"Bug: {Id} is under process, it is assigned To: {AssignedTo}, the estimated hours is {estimatedHours}");
        }
        public override void Display() {
            Console.WriteLine($"Task #{Id}:{Title} | Estimated Hours: {estimatedHours}");
            Console.WriteLine($"Assigned To: {AssignedTo}");
        }
    }
}