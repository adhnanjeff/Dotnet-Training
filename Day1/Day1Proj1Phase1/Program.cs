// See https://aka.ms/new-console-template for more information
using Day1Proj1Phase1.Models;
using System;

public class Program {
    public static void Main(string[] args) {
        User user = new User(1, "Alice", "Developer");
        Ticket ticket = new Ticket(101, "Bug in Login", "Unable to login with valid credentials", user);
        Ticket.DisplayTicket(ticket);
        ticket.closeTicket();
        Console.WriteLine("\nAfter closing the ticket:");
        Ticket.DisplayTicket(ticket);
    }
}
