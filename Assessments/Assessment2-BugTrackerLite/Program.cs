using System;
using System.Collections.Generic;
using Assessment2_BugTrackerLite.Data;
using Assessment2_BugTrackerLite.Models;
using Assessment2_BugTrackerLite.Services;

namespace Assessment2_BugTrackerLite
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            UserService userService = new UserService(context);
            TicketService ticketService = new TicketService(context);

            Console.WriteLine("Welcome to Support Desk System!");

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Ticket");
                Console.WriteLine("3. Add Tags to Ticket");
                Console.WriteLine("4. Resolve Ticket");
                Console.WriteLine("5. View All Tickets with Tags");
                Console.WriteLine("6. Exit\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Enter user name: ");
                        string userName = Console.ReadLine();
                        userService.CreateUser(userName);
                        break;

                    case "2":
                        var users = userService.GetAllUsers();
                        if (users.Count == 0)
                        {
                            Console.WriteLine("No users found. Create a user first.");
                            break;
                        }

                        Console.WriteLine("Select user:");
                        for (int i = 0; i < users.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {users[i].UserName}");
                        }
                        int userIndex = int.Parse(Console.ReadLine());
                        var selectedUser = users[userIndex - 1];

                        Console.Write("Enter ticket title: ");
                        var title = Console.ReadLine();
                        Console.Write("Enter ticket description: ");
                        var desc = Console.ReadLine();

                        ticketService.CreateTicket(selectedUser.UserId, title, desc);
                        break;

                    case "3":
                        var allTickets = ticketService.GetAllTicketsWithTags();
                        if (allTickets.Count == 0)
                        {
                            Console.WriteLine("No tickets found.");
                            break;
                        }

                        Console.WriteLine("Select a ticket:");
                        for (int i = 0; i < allTickets.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {allTickets[i].Title}");
                        }

                        if (!int.TryParse(Console.ReadLine(), out int ticketIndex) || ticketIndex < 1 || ticketIndex > allTickets.Count)
                        {
                            Console.WriteLine("Invalid selection.");
                            break;
                        }

                        var selectedTicket = allTickets[ticketIndex - 1];

                        Console.Write("Enter first tag: ");
                        var tag1 = Console.ReadLine();
                        Console.Write("Enter second tag: ");
                        var tag2 = Console.ReadLine();

                        ticketService.AddTagsToTicket(selectedTicket.TicketId, new List<string> { tag1, tag2 });
                        break;

                    case "4":
                        var openTickets = ticketService.GetAllTicketsWithTags()
                                                      .FindAll(t => t.Status == "Open");

                        if (openTickets.Count == 0)
                        {
                            Console.WriteLine("No open tickets to resolve.");
                            break;
                        }

                        Console.WriteLine("Select a ticket to resolve:");
                        for (int i = 0; i < openTickets.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {openTickets[i].Title}");
                        }

                        if (!int.TryParse(Console.ReadLine(), out int resolveIndex) || resolveIndex < 1 || resolveIndex > openTickets.Count)
                        {
                            Console.WriteLine("Invalid selection.");
                            break;
                        }

                        var ticketToResolve = openTickets[resolveIndex - 1];
                        ticketService.ResolveTicket(ticketToResolve.TicketId);
                        break;

                    case "5":
                        var tickets = ticketService.GetAllTicketsWithTags();
                        foreach (var t in tickets)
                        {
                            Console.WriteLine($"\nTicket: {t.Title} raised by {t.User.UserName} (Status: {t.Status})");
                            foreach (var tag in t.TicketTags)
                            {
                                Console.WriteLine($" - Tag: {tag.Tag.TagName}");
                            }
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
