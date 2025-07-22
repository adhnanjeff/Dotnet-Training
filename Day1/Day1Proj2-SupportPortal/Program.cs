// See https://aka.ms/new-console-template for more information
using Day1Proj2.Models;
using System;
using System.Net.Sockets;

public class Program
{
    public static void Main(string[] args)
    {
        Agent agent1 = new Agent(1, "Alice", "Developer");
        Agent agent2 = new Agent(2, "Bob", "Tester");

        Request req1 = new Request(101, "Unable to login with valid credentials", agent2, agent1);
        Request req2 = new Request(102, "Add dark mode to the application", agent1, agent2);

        Console.WriteLine("----- Request Summary Before Reassignment -----");
        Request.DisplayRequest(req1);
        Request.DisplayRequest(req2);

        // Reassigning requests
        Console.WriteLine("\n----- Reassigning Requests -----");
        Request.ReassignRequest(req1, agent2);
        Request.ReassignRequest(req2, agent1);

        // Resolving requests
        req1.ResolveRequest();
        req2.ResolveRequest();

        Console.WriteLine("\n----- Request Summary After Closing -----");
        Request.DisplayRequest(req1);
        Request.DisplayRequest(req2);
    }
}
