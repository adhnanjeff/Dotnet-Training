using EventEase.Core.Entities;
using EventEase.Core.Interfaces;

namespace EventEase.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void AddEvent(Event e)
        {
            _eventRepository.Add(e);
        }

        public void UpdateEvent(Event e)
        {
            _eventRepository.Update(e);
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.Delete(id);
        }

        public List<Event> GetAllEvents()
        {
            return _eventRepository.GetAll();
        }

        public Event? GetEventById(int id)
        {
            return _eventRepository.GetById(id);
        }
    }
}
