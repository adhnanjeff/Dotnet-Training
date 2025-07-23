using Day2Proj2.Models;
using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        List<SupportTicket> tickets = new List<SupportTicket>();
        BugReport br = new BugReport(1, "Login Issue", "Unable to login with valid credentials", "Alice", "High");
        FeatureRequest fr = new FeatureRequest(2, "Add Dark Mode", "Implement dark mode in the application", "Alice", "Bob", "2023-12-31");

        tickets.Add(br);
        tickets.Add(fr);

        Console.WriteLine("All Support Tickets:");
        foreach (SupportTicket ticket in tickets)
        {
            ticket.Display();
        }

        Console.WriteLine("\nReporting Tickets:");
        br.ReportStatus();
        fr.ReportStatus();
    }
}

