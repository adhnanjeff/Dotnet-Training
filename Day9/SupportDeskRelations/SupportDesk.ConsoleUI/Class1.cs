using Microsoft.EntityFrameworkCore;
using SupportDesk.Application.Services;
using SupportDesk.Core.Entities;
using SupportDesk.Infrastructure.Data;

namespace SupportDesk.ConsoleUI;

public class Class1
{
    public static void Main(string[] args)
    {
        AppDbContext appDbContext = new AppDbContext();
        using (var context = appDbContext)
        {

            // Clear old data
            // 1. Remove all records from dependent join table first
            context.TicketTags.RemoveRange(context.TicketTags);
            // 2. Then remove Tickets, Tags, Users
            context.Tickets.RemoveRange(context.Tickets);
            context.Tags.RemoveRange(context.Tags);
            context.Users.RemoveRange(context.Users);

            context.SaveChanges();

            User user = new User
            {
                UserName = "Jeff",
            };
            context.Users.Add(user);

            Ticket ticket = new Ticket
            {
                Title = "Login Issue",
                UserId = 1,
                User = user
            };
            context.Tickets.Add(ticket);

            var tags = new[] {
                    new Tag { TagName = "Bug" },
                    new Tag { TagName = "UI" }
                };

            context.Tags.AddRange(tags);

            var ticketTag1 = new TicketTag
            {
                Ticket = ticket,
                Tag = tags[0] // "Bug"
            };
            var ticketTag2 = new TicketTag
            {
                Ticket = ticket,
                Tag = tags[1] // "UI"
            };

            context.TicketTags.AddRange(ticketTag1, ticketTag2);
            context.SaveChanges();

            ITicketService ticketService = new TicketService(context);

            Console.WriteLine("📋 All Tickets:");
            foreach (var t in ticketService.GetAllTickets())
                Console.WriteLine($"- {t.Title}");

            Console.WriteLine("\n👥 All Users With Tickets:");
            foreach (var t in ticketService.GetAllUsersWithTickets())
                Console.WriteLine($"- Ticket: {t.Title}, UserId: {t.UserId}");

            //Console.WriteLine("\n🏷️ All Tickets With Tags:");
            //foreach (var t in ticketService.GetAllTicketsWithTags())
            //    Console.WriteLine($"- Ticket: {t.Title}");

            Console.WriteLine("\n👤 Users With Tickets:");
            foreach (var t in ticketService.GetUsersWithTickets())
                Console.WriteLine($"- {t.Title}");

            Console.WriteLine("\n📊 Ticket Count By Tag:");
            foreach (var item in ticketService.GetTicketTagCounts())
                Console.WriteLine($"- Tag: {item.TagName}, Count: {item.TicketCount}");

            Console.WriteLine("\n📊 Ticket Count By User:");
            foreach (var item in ticketService.GetTicketCountByUser())
                Console.WriteLine($"- User: {item.UserName}, Count: {item.TicketCount}");

            Console.WriteLine("\n🔍 Tickets By User ID (e.g., 1):");
            foreach (var t in ticketService.GetTicketsByUserId(24))
                Console.WriteLine($"- {t.Title}");

            //Console.WriteLine("\n🔍 Ticket By Tag ID (e.g., 1):");
            //var tagTicket = ticketService.GetTicketByTagId(7);
            //if (tagTicket != null)
            //    Console.WriteLine($"- Ticket: {tagTicket.Title}");
            //else
            //    Console.WriteLine("- No ticket found for given tag ID");

            //Console.WriteLine("\n🎟️ Ticket With User And Tag Names:");
            //foreach (var obj in ticketService.GetTicketWithUserAndTagNames())
            //    Console.WriteLine($"- {obj}");
        }
    }
}
