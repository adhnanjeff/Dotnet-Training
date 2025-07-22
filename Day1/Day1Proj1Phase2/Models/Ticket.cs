using System;

namespace Day1Proj1Phase2.Models
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
            Status = "New";
            CreatedBy = createdBy;
            TicketPriority = tp;
            AssignedTo = at;
            IssueDate = DateTime.Now;
            CloseDate = DateTime.MinValue;
        }

        public static void DisplaySummary(Ticket ticket)
        {
            Console.WriteLine($"Ticket #{ticket.TicketId}: {ticket.Title} - {ticket.Status} - {ticket.TicketPriority} - Assigned to: {ticket.AssignedTo.Name}\n   Created On: {ticket.IssueDate}");
        }

        public static void ReassignTicket(Ticket ticket, User newAssignee)
        {
            ticket.AssignedTo = newAssignee;
            Console.WriteLine($"Ticket #{ticket.TicketId} has been reassigned to {ticket.AssignedTo.Name}.");
        }

        public void CloseTicket()
        {
            Status = "Closed";
            CloseDate = DateTime.Now;
        }
    }
}
