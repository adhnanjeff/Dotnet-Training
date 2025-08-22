
using EventEase.Core.Entities;

namespace EventEase.Core.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        public Task<List<User>> GetAttendeesByEventIdAsync(int eventId);
    }
}
