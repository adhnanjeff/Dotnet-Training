using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Assessment2_BugTrackerLite.Data;
using Assessment2_BugTrackerLite.Models;

namespace Assessment2_BugTrackerLite.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;

        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTicket(int userId, string title, string description)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var ticket = new Ticket
            {
                Title = title,
                TicketDesc = description,
                Status = "Open",
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                UserId = userId,
                User = user
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            Console.WriteLine("Ticket created successfully.");
        }

        public List<Ticket> GetAllTicketsWithTags()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .ToList();
        }

        public void ResolveTicket(int ticketId)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == ticketId);
            if (ticket == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            ticket.Status = "Resolved";
            _context.SaveChanges();
            Console.WriteLine($"Ticket '{ticket.Title}' resolved successfully.");
        }

        public void AddTagsToTicket(int ticketId, List<string> tagNames)
        {
            var ticket = _context.Tickets
                .Include(t => t.TicketTags)
                .FirstOrDefault(t => t.TicketId == ticketId);

            if (ticket == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            foreach (var tagName in tagNames)
            {
                var tag = _context.Tags.FirstOrDefault(t => t.TagName == tagName)
                          ?? new Tag { TagName = tagName };

                _context.TicketTags.Add(new TicketTag
                {
                    Ticket = ticket,
                    Tag = tag
                });
            }

            _context.SaveChanges();
            Console.WriteLine("Tags added to ticket successfully.");
        }
    }
}
