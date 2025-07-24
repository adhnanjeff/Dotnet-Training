using System;

namespace Phase3_IssueTracker.Models
{
    public abstract class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }

        public Issue(int id, string title, string assignedto)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));
            if (string.IsNullOrWhiteSpace(assignedto))
                throw new ArgumentException("Title cannot be empty.", nameof(assignedto));
            Id = id;
            Title = title;
            AssignedTo = assignedto;
            Status = "Open"; // Default status
        }

        public void Close() => Status = "Closed";

        public abstract void Display();
    }
}