
using SupportDesk.Core.Entities;

namespace SupportDesk.Application.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        List<Ticket> GetAllUsersWithTickets();
        // <Ticket> GetAllTicketsWithTags();
        List<Ticket> GetUsersWithTickets();
        List<(string TagName, int TicketCount)> GetTicketTagCounts();
        List<(string UserName, int TicketCount)> GetTicketCountByUser();
        List<Ticket> GetTicketsByUserId(int userId);
        Ticket? GetTicketByTagId(int tagId);
        List<object> GetTicketWithUserAndTagNames();

        //List<Ticket> SortByPriority();
        //List<Ticket> SortByStatus();

    }
}
