using System;

namespace Day1Proj1Phase1.Models
{
    public class Ticket
    {
        public int TicketId { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; private set; }
        public User CreatedBy { get; set; }

        public Ticket(int id, string title, string description, User createdBy)
        {
            TicketId = id;
            Title = title;
            Description = description;
            Status = "New"; // Default status
            CreatedBy = createdBy;
        }

        public void closeTicket()
        {
            Status = "Closed";
        }

        public static void DisplayTicket(Ticket ticket)
        {
            Console.WriteLine("------ Ticket Info ------");
            Console.WriteLine($"TicketId: {ticket.TicketId}");
            Console.WriteLine($"Title: {ticket.Title}");
            Console.WriteLine($"Description: {ticket.Description}");
            Console.WriteLine($"Status: {ticket.Status}");
            Console.WriteLine("Created By:");
            User.DisplayUser(ticket.CreatedBy);
        }
    }
}
