using System.Net.NetworkInformation;
using Assessment2_BugTrackerLite.Data;
using Assessment2_BugTrackerLite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace Assessment2_BugTrackerLite {
    class Program {
        private static void CreateUser(AppDbContext context) {
            Console.Write("Enter user name: ");
            string userName = Console.ReadLine();
            var user = new User { UserName = userName };
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine($"User '{userName}' created successfully.");
        }

        private static void CreateTicket(AppDbContext context) {
            var users = context.Users.ToList();
            if (!users.Any()) {
                Console.WriteLine("No users available. Please create a user first.");
                return;
            }

            Console.WriteLine("Select user:");
            for (int i = 0; i < users.Count; i++) {
                Console.WriteLine($"{i + 1}. {users[i].UserName}");
            }

            int index = int.Parse(Console.ReadLine());  

            var selectedUser = users[index - 1];
            Console.Write("Enter ticket title: ");
            var title = Console.ReadLine();
            Console.Write("Enter ticket description: ");
            var desc = Console.ReadLine();
            var ticket = new Ticket
            {
                Title = title,
                TicketDesc = desc,
                Status = "Open",
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                UserId = selectedUser.UserId,
                User = selectedUser
            };

            context.Tickets.Add(ticket);
            context.SaveChanges();
            Console.WriteLine("Ticket created successfully.");
        }

        private static void CreateTagsAndTicketTags(AppDbContext context)
        {
            Console.Write("Enter tag1: ");
            var tag = Console.ReadLine();
            Console.Write("Enter tag2: ");
            var tag2 = Console.ReadLine();
            var tags = new[] {
                new Tag { TagName = tag },
                new Tag { TagName = tag2 }
            };

            context.Tags.AddRange(tags);

            var ticket = context.Tickets.FirstOrDefault();
            if (ticket != null)
            {
                context.TicketTags.AddRange(
                    new TicketTag { Ticket = ticket, Tag = tags[0] },
                    new TicketTag { Ticket = ticket, Tag = tags[1] }
                );
            }

            context.SaveChanges();
            Console.WriteLine("Tags and TicketTags created successfully.");
        }

        private static void resolveTickets(AppDbContext context)
        {
            var tickets = context.Tickets.Where(t => t.Status == "Open").ToList();
            if (!tickets.Any())
            {
                Console.WriteLine("No open tickets to resolve.");
                return;
            }
            Console.WriteLine("Select a ticket to resolve:");
            for (int i = 0; i < tickets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tickets[i].Title}");
            }
            int index = int.Parse(Console.ReadLine());
            var selectedTicket = tickets[index - 1];
            selectedTicket.Status = "Resolved";
            context.SaveChanges();
            Console.WriteLine($"Ticket '{selectedTicket.Title}' resolved successfully.");
        }

        private static void ViewAllTickets(AppDbContext context)
        {
            var tickets = context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .ToList();

            foreach (var t in tickets)
            {
                Console.WriteLine($"Ticket: {t.Title} raised by {t.User.UserName}");
                foreach (var tag in t.TicketTags.Select(tt => tt.Tag))
                {
                    Console.WriteLine($" - Tag: {tag.TagName}");
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Support Desk System!");
            using var context = new AppDbContext();

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Ticket");
                Console.WriteLine("3. Add Tags and TicketTags");
                Console.WriteLine("4. Resolve Ticket");
                Console.WriteLine("5. View All Tickets with Tags");
                Console.WriteLine("6. Exit\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateUser(context);
                        break;
                    case "2":
                        CreateTicket(context);
                        break;
                    case "3":
                        CreateTagsAndTicketTags(context);
                        break;
                    case "4":
                        resolveTickets(context);
                        break;
                    case "5":
                        ViewAllTickets(context);
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