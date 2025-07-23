using System;

namespace Day2Proj1Phase1_IssueTracker.Models
{
    public class Issue {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AssignedTo { get; set; }

        public Issue(int id, string title, string assignedto) { 
            Id = id;
            Title = title;
            AssignedTo = assignedto;
        }

        public virtual void Display() { 
            // virtual function to allow overriding
            Console.WriteLine($"Issue ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Assigned To: {AssignedTo}");
        }
    }
}