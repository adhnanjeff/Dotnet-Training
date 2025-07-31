using System.Net.NetworkInformation;
using SupportDesk_Phase1.Data;
using SupportDesk_Phase1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SupportDesk_Phase1 {
    class Program {
        public static void Main(string[] args) {
            AppDbContext appDbContext = new AppDbContext();
            using (var context = appDbContext) {

                // Clear old data
                // 1. Remove all records from dependent join table first
                context.TicketTags.RemoveRange(context.TicketTags);
                // 2. Then remove Tickets, Tags, Users
                context.Tickets.RemoveRange(context.Tickets);
                context.Tags.RemoveRange(context.Tags);
                context.Users.RemoveRange(context.Users);

                context.SaveChanges();

                User user = new User {
                    UserName = "Jeff",
                };
                context.Users.Add(user);

                Ticket ticket = new Ticket {
                    Title = "Login Issue",
                    UserId = 1,
                    User = user
                };
                context.Tickets.Add(ticket);

                var tags = new [] {
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

                var ticketsWithTags = context.Tickets
                    .Include(t => t.User)
                    .Include(tt => tt.TicketTags)
                        .ThenInclude(t => t.Tag)
                    .ToList();

                foreach (var t in ticketsWithTags)
                {
                    Console.WriteLine($"Ticket: {t.Title} raised by {t.User.UserName}");
                    foreach (var tt in t.TicketTags.Select(tt => tt.Tag))
                    {
                        Console.WriteLine($" - Tag: {tt.TagName}");
                    }

                }
            }
        }
    } 
}
