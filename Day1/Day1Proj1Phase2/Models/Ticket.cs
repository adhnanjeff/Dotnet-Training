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
        public string TicketPriority { get; set; }
        public User AssignedTo { get; set; }
        public DateTime IssueDate { get; private set; }
        public DateTime CloseDate { get; private set; }


        public Ticket(int id, string title, string description, User createdBy, string tp, User at)
        {
            TicketId = id;
            Title = title;
            Description = description;
            Status = "New"; // Default status
            CreatedBy = createdBy;
            TicketPriority = tp;
            AssignedTo = at;
            IssueDate = DateTime.Now;
            CloseDate = DateTime.MinValue; // Default value indicating ticket is not closed yet
        }

        public void displaySummary()
        {
            Console.WriteLine($"Ticket #{ticket.TicketId}: {ticket.Title} - {ticket.Status} - {ticket.TicketPriority} - Assigned to: {AssignedTo.name}\r\n   Created On: {Date}");
        }

        public void closeTicket()
        {
            Status = "Closed";
            CloseDate = DateTime.Now;
        }

        //public static void DisplayTicket(Ticket ticket)
        //{
        //    Console.WriteLine("------ Ticket Info ------");
        //    Console.WriteLine($"TicketId: {ticket.TicketId}");
        //    Console.WriteLine($"Ticket Priority: {ticket.TicketPriority}");
        //    Console.WriteLine($"Title: {ticket.Title}");
        //    Console.WriteLine($"Description: {ticket.Description}");
        //    Console.WriteLine($"Status: {ticket.Status}");
        //    Console.WriteLine("Created By:");
        //    User.DisplayUser(ticket.CreatedBy);
        //    Console.WriteLine($"Assigned To: {AssignedTo.name}");
        }
    }
}
