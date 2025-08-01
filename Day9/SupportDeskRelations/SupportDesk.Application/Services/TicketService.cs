using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;
using SupportDesk.Infrastructure.Data;

namespace SupportDesk.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;

        public TicketService(AppDbContext context)
        {
            _context = context;
        }
        public List<Ticket> GetAllTickets() => _context.Tickets.ToList();
        

        public List<Ticket> GetAllUsersWithTickets() => _context.Tickets.Include(t => t.User).ToList();

        // public List<Ticket> GetAllTicketsWithTags() => _context.Tickets.Include(t => t.Tags).ToList();
            
        public List<Ticket> GetUsersWithTickets() =>_context.Tickets.Include(t => t.User).ToList();

        public List<(string TagName, int TicketCount)> GetTicketTagCounts()
        {
            return _context.Tags
                .Select(g => new { g.TagName, TicketCount = g.TicketTags.Count })
                .ToList()
                .Select(x => (x.TagName, x.TicketCount))
                .ToList();
        }

        public List<(string UserName, int TicketCount)> GetTicketCountByUser()
        {
            return _context.Users
                .Select(g => new { g.UserName, TicketCount = g.Tickets.Count })
                .ToList()
                .Select(x => (x.UserName, x.TicketCount))
                .ToList();
        }

        public List<Ticket> GetTicketsByUserId(int userId)
        {
            return _context.Tickets
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public Ticket? GetTicketByTagId(int tagId)
        {
            return _context.Tickets
                .Include(t => t.Tags)
                .FirstOrDefault(t => t.Tags.Any(tag => tag.TagId == tagId));
        }

        public List<object> GetTicketWithUserAndTagNames()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Include(t => t.Tags)
                .Select(static t => new
                {
                    TicketId = t.TicketId,
                    Title = t.Title,
                    UserName = t.User.UserName,
                    TagNames = t.Tags.Select(tag => tag.TagName).ToList()
                })
                .ToList<object>();
        }

        //public List<Ticket> SortByPriority()
        //{
        //    return _context.Tickets
        //        .OrderBy(t => t.Priority)
        //        .ToList();
        //}

        //public List<Ticket> SortByStatus()
        //{
        //    return _context.Tickets
        //        .OrderBy(t => t.Status)
        //        .ToList();
        //}
    }
}
