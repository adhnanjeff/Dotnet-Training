using EventEase.Core.Entities;
using EventEase.Core.Interfaces;

namespace EventEase.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly List<Event> _events = new();

        public void Add(Event e) { 
            _events.Add(e);
        }

        public void Update(Event e) { 
            var existingEvent = GetById(e.Id);
            if (existingEvent != null) { 
                existingEvent.Title = e.Title;
                existingEvent.Description = e.Description;
                existingEvent.EventDate = e.EventDate;
                existingEvent.Location = e.Location;
            }
        }

        public void Delete(int id)
        {
            var deleteEvent = GetById(id);
            if (deleteEvent != null) {
                _events.Remove(deleteEvent);
            }
        }
        public Event? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public List<Event> GetAll() => _events;
    }
}
