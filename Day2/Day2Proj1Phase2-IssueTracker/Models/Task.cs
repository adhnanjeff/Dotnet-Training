using System;
namespace Day2Proj1Phase2_IssueTracker.Models
{
    public class Task : Issue, IReportable
    {
        public int estimatedHours { get; set; }
        public Task(int id, string title, string assignedTo, int estimatedHours) : base(id, title, assignedTo)
        {
            if (estimatedHours <= 0)
                throw new ArgumentException("Estimated hours must be greater than zero.", nameof(estimatedHours));
            this.estimatedHours = estimatedHours;
        }
        // Implementing the IReportable interface method
        public void ReportStatus()
        {
            Console.WriteLine($"Task: {Id} is under process, it is assigned To: {AssignedTo}, the estimated hours is {estimatedHours}");
            Status = "In Progress"; // Update status to In Progress
        }
        public void getSummary()
        {
            Console.WriteLine($"Task Summary: ID={Id}, Title={Title}, AssignedTo={AssignedTo}, EstimatedHours={estimatedHours}");
        }
        public override void Display()
        {
            Status = "closed";
            Console.WriteLine($"Task #{Id}:{Title} | Estimated Hours: {estimatedHours}");
            Console.WriteLine($"Assigned To: {AssignedTo}");
            Console.WriteLine($"Status: {Status}"); 
        }
    }
}