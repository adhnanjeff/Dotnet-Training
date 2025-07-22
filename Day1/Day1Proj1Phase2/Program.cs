// See https://aka.ms/new-console-template for more information
using Day1Proj1Phase2.Models;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        User user1 = new User(1, "Alice", "Developer");
        User user2 = new User(2, "Bob", "Tester");
        User user3 = new User(3, "Charlie", "Manager");

        Ticket ticket1 = new Ticket(101, "Bug in Login", "Unable to login with valid credentials", user1, "HIGH", user2);
        Ticket ticket2 = new Ticket(102, "Feature Request", "Add dark mode to the application", user2, "MEDIUM", user3);
        Ticket ticket3 = new Ticket(103, "Performance Issue", "Application is slow on large datasets", user3, "LOW", user1);

        Console.WriteLine("----- Ticket Summary Before Reassignment -----");
        Ticket.DisplaySummary(ticket1);
        Ticket.DisplaySummary(ticket2);
        Ticket.DisplaySummary(ticket3);

        // Reassigning tickets
        Console.WriteLine("\n----- Reassigning Tickets -----");
        Ticket.ReassignTicket(ticket1, user3);
        Ticket.ReassignTicket(ticket2, user1);

        // Closing tickets
        ticket1.CloseTicket();
        ticket2.CloseTicket();
        ticket3.CloseTicket();

        Console.WriteLine("\n----- Ticket Summary After Closing -----");
        Ticket.DisplaySummary(ticket1);
        Ticket.DisplaySummary(ticket2);
        Ticket.DisplaySummary(ticket3);
    }
}
