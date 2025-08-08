

using EventEase.Core.Entities;

namespace EventEase.Core.Interfaces
{
    public interface IEventService
    {
        void AddEvent(Event e);
        void UpdateEvent(Event e);
        void DeleteEvent(int id);
        List<Event> GetAllEvents();
        Event? GetEventById(int id);
    }
}
