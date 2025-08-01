using Assessment2_BugTrackerLite.Models;

namespace Assessment2_BugTrackerLite.Services
{
    public interface ITicketService
    {
        void CreateTicket(int userId, string title, string description);
        List<Ticket> GetAllTicketsWithTags();
        void ResolveTicket(int ticketId);
        void AddTagsToTicket(int ticketId, List<string> tagNames);
    }
}
