using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SupportDesk_Phase2.Models;
using SupportDesk_Phase2.Data;

namespace SupportDesk_Phase2
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.TicketHistories.RemoveRange(context.TicketHistories);
                context.TicketTags.RemoveRange(context.TicketTags);
                context.Tickets.RemoveRange(context.Tickets);
                context.Tags.RemoveRange(context.Tags);
                context.CustomerProfiles.RemoveRange(context.CustomerProfiles);
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                var agent = new User
                {
                    UserName = "Subashini",
                    Role = "SupportAgent"
                };

                var customer = new User
                {
                    UserName = "Jeff",
                    Role = "Customer",
                    CustomerProfile = new CustomerProfile
                    {
                        Address = "123 Main St",
                        Phone = "9876543210"
                    }
                };

                context.Users.AddRange(agent, customer);
                context.SaveChanges();

                var tags = new List<Tag>
                {
                    new Tag { TagName = "Bug" },
                    new Tag { TagName = "UI" }
                };
                context.Tags.AddRange(tags);
                context.SaveChanges();

                var ticket = new Ticket
                {
                    Title = "Login issue on mobile",
                    RaisedById = customer.UserId, 
                    AssignedToId = agent.UserId,
                    Tags = tags
                };
                context.Tickets.Add(ticket);
                context.SaveChanges();

                var history = new TicketHistory
                {
                    TicketId = ticket.TicketId,
                    TicketDesc = "Ticket created for login issue",
                    TimeStamp = DateTime.Now
                };
                context.TicketHistories.Add(history);
                context.SaveChanges();

                ticket.Title = "Updated: Login fails on iOS";
                context.Tickets.Update(ticket);

                var updateHistory = new TicketHistory
                {
                    TicketId = ticket.TicketId,
                    TicketDesc = "Title updated to 'Updated: Login fails on iOS'",
                    TimeStamp = DateTime.Now
                };
                context.TicketHistories.Add(updateHistory);
                context.SaveChanges();

                var tickets = context.Tickets
                    .Include(t => t.RaisedBy)
                    .Include(t => t.AssignedTo)
                    .Include(t => t.Tags)
                    .Include(t => t.TicketHistories)
                    .ToList();

                foreach (var t in tickets)
                {
                    Console.WriteLine($"🎫 Ticket ID: {t.TicketId}");
                    Console.WriteLine($"Title: {t.Title}");
                    Console.WriteLine($"Raised by: {t.RaisedBy?.UserName} (Role: {t.RaisedBy?.Role})");
                    Console.WriteLine($"Assigned to: {t.AssignedTo?.UserName} (Role: {t.AssignedTo?.Role})");
                    Console.WriteLine("Tags: " + string.Join(", ", t.Tags.Select(tag => tag.TagName)));
                    Console.WriteLine("History:");
                    foreach (var h in t.TicketHistories)
                    {
                        Console.WriteLine($" - {h.TimeStamp}: {h.TicketDesc}");
                    }
                    Console.WriteLine(new string('-', 50));
                }

                var userWithProfile = context.Users
                    .Include(u => u.CustomerProfile)
                    .FirstOrDefault(u => u.UserId == customer.UserId);

                if (userWithProfile?.CustomerProfile != null)
                {
                    userWithProfile.CustomerProfile.Address = "456 Updated Address";
                    userWithProfile.CustomerProfile.Phone = "9999999999";
                    context.SaveChanges();
                }

                Console.WriteLine("✅ All updates and relationships processed successfully.");
            }
        }
    }
}
