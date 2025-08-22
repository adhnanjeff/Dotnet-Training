using EventEase.Core.Entities;
using EventEase.Core.Interfaces;

namespace EventEase.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly List<Event> _events = new();

        public async Task AddAsync(Event e)
        {
            _events.Add(e);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Event e)
        {
            var existingEvent = _events.FirstOrDefault(ev => ev.Id == e.Id);
            if (existingEvent != null)
            {
                existingEvent.Title = e.Title;
                existingEvent.Description = e.Description;
                existingEvent.EventDate = e.EventDate;
                existingEvent.Location = e.Location;
                existingEvent.Participants = e.Participants;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var deleteEvent = _events.FirstOrDefault(e => e.Id == id);
            if (deleteEvent != null)
                _events.Remove(deleteEvent);

            await Task.CompletedTask;
        }

        public Task<List<User>> GetAttendeesByEventIdAsync(int eventId)
        {
            var ev = _events.FirstOrDefault(e => e.Id == eventId);
            return Task.FromResult(ev?.Participants?.ToList() ?? new List<User>());
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await Task.FromResult(_events);
        }
    }
}
