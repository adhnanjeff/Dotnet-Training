using System;

namespace Day2Proj2.Models;

public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreateBy { get; set; }
    public string Status { get; set; }

    public SupportTicket(int id, string title, string description, string createBy) {
        if (id <= 0)
            throw new ArgumentException("ID must be a positive integer.", nameof(id));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));
        if (string.IsNullOrWhiteSpace(createBy))
            throw new ArgumentException("Created By cannot be empty.", nameof(createBy));
        Id = id;
        Title = title;
        Description = description;
        CreateBy = createBy;
        Status = "Open"; // Default status
    }

    public void closeTicket() {
        if (Status == "Closed") {
            Console.WriteLine("Ticket is already closed.");
            return;
        }
        Status = "Closed";
        Console.WriteLine($"Ticket #{Id} has been closed.");
    }

    public virtual void Display() {
        Console.WriteLine($"Support Ticket ID: {Id}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Created By: {CreateBy}");
        Console.WriteLine($"Status: {Status}");
    }
}